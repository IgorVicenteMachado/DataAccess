using System;
using Dapper;
using dataAccess.DAPPER.Models;
using Microsoft.Data.SqlClient;

namespace DATAACCESS.DAPPER
{
    class Program
    {
       

        static void Main(string[] args)
        {
            const string CONNECTION_STRING =
                @"Server = localhost,1433; Database=praticandodb; User ID=sa; password=!@#$%12345;TrustServerCertificate=True";
           


            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                //InsertCategory(connection);
                //UpdateCategory(connection);
                ListCategories(connection);
            }
        }

        private static void UpdateCategory(SqlConnection connection)
        {
            var queryUpdate = "update [category] Set [Title]=@paramTitle where [Id]=@paramId";
            var rows = connection.Execute(queryUpdate, 
            new {
                paramTitle = "New Title",
                paramId = "1a74f443-de90-4ff6-b851-7be52ca305bc"
            });

            System.Console.WriteLine(rows + " registros foram atualizados");
        }

        private static void InsertCategory(SqlConnection connection)
        {
            var queryInsert = $@"insert into Category values 
                ( @paramId, @paramTitle , @paramUrl, @paramSummary, @paramOrder, @paramDescription, @paramFeatured )";

            var category = new Category(Guid.NewGuid(), "title", "url", "summary", 9, "cloud com azure da microsoft", false);

            var rows = connection.Execute(queryInsert, new
            {
                paramId = category.Id,                     //@paramId
                paramTitle = category.Title,               //@paramTitle
                paramUrl = category.Url,                   //@paramUrl
                paramSummary = category.Summary,           //@paramSummary
                paramOrder = category.Order,               //@paramOrder
                paramDescription = category.Description,   //@paramDescription
                paramFeatured = category.Featured          //@paramFeatured
            });
        }

        private static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("select [Id], [title] from [category] order by [Title];");

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} | {item.Title} ");
            }
        }
    }
}
