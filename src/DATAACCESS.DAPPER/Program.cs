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
            
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon.aws";
            category.Summary = "aws cloudy";
            category.Order = 8;
            category.Description = "Serviços em nuvem com AWS";
            category.Featured = true;

             var insertSql = $@"insert into Category values 
                ( @paramId, @paramTitle , @paramUrl, @paramSummary, @paramOrder, @paramDescription, @paramFeatured )";


            using (var connection = new SqlConnection(CONNECTION_STRING) )
            {
                var rows = connection.Execute(insertSql, new {
                    paramId = category.Id,                     //@paramId
                    paramTitle = category.Title,               //@paramTitle
                    paramUrl = category.Url,                   //@paramUrl
                    paramSummary = category.Summary,           //@paramSummary
                    paramOrder = category.Order,               //@paramOrder
                    paramDescription = category.Description,   //@paramDescription
                    paramFeatured = category.Featured          //@paramFeatured
                });

                System.Console.WriteLine(rows);

                var categories = connection.Query<Category>("select [Id], [title] from [category] order by [Title];");

                foreach(var item in categories)
                {
                    Console.WriteLine($"{item.Id} | {item.Title}");
                }
            }
        }
    }
}
