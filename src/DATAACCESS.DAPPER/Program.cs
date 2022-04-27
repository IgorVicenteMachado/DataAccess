using System;
using Dapper;
using dataAccess.DAPPER.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DATAACCESS.DAPPER
{
    class Program
    {
       

        static void Main(string[] args)
        {
            const string CONNECTION_STRING =
                @"Server = localhost,1433; Database=balta; User ID=sa; password=!@#$%12345;TrustServerCertificate=True";
           


            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                //GetCategory(connection);
                //InsertCategory(connection);
                //UpdateCategory(connection);
                //DeleteCategory(connection);
                //ListCategories(connection);
                //CreateManyCategory(connection);
                //ExecuteProcedure(connection);
                //ExecuteReadProcedure(connection);
                ExecuteScalar(connection);
            }
        }
        #region GetOneItemFromCategory
        static void GetCategory(SqlConnection connection)
        {
            var queryGetOne = "SELECT TOP 1 [Id], [Title] FROM [Category] WHERE [Id]=@paramId";

            var category = connection.QueryFirstOrDefault<Category>(queryGetOne,
                new
                {
                    paramId = "af3407aa-11ae-4621-a2ef-2028b85507c4"
                });
            Console.WriteLine($"{category.Id} - {category.Title}");
        }
        #endregion

        #region DeleteOneItemFromCategory
        private static void DeleteCategory(SqlConnection connection)
        {
            var queryDelete = "Delete [category] where [Id]=@paramId";
            var rows = connection.Execute(queryDelete, 
            new {
                paramId = "7c821dc5-3877-4b28-a71e-40d706f3e2c5" //id copiado da base de dados
            });

            System.Console.WriteLine(rows + " registros foram atualizados");
        }
        #endregion

        #region UpdateOneItemFromCategory
        private static void UpdateCategory(SqlConnection connection)
        {
            var queryUpdate = "update [category] Set [Title]=@paramTitle where [Id]=@paramId";
            var rows = connection.Execute(queryUpdate, 
            new {
                paramTitle = "New Title",
                paramId = "1a74f443-de90-4ff6-b851-7be52ca305bc" //id copiado da base de dados
            });

            System.Console.WriteLine(rows + " registros foram atualizados");
        }
        #endregion

        #region InsertOneItemInCategory
        private static void InsertCategory(SqlConnection connection)
        {
            var queryInsert = $@"insert into Category values 
                ( @paramId, @paramTitle , @paramUrl, @paramSummary, @paramOrder, @paramDescription, @paramFeatured )";

            var category = new Category(Guid.NewGuid(), "Microsoft azure", "url", "summary", 9, "cloud com azure da microsoft", false);

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
        #endregion

        #region ListAllItemsFromCategory
        private static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("select [Id], [title] from [category] order by [Title];");

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} | {item.Title} ");
            }
        }
        #endregion

        #region AddManyItemsInCategory
        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category(Guid.NewGuid(),"Amazon AWS","amazon","...",12, "aws cloud", false );


            var category2 = new Category(Guid.NewGuid(), "title 2", "url...", "sumary...", 13, "description ...", true);


             var queryInsert = $@"insert into Category values 
                ( @paramId, @paramTitle , @paramUrl, @paramSummary, @paramOrder, @paramDescription, @paramFeatured )";

            var rows = connection.Execute(queryInsert, new[]{
                new
                {
                    paramId = category.Id,                     
                    paramTitle = category.Title,               
                    paramUrl = category.Url,                   
                    paramSummary = category.Summary,           
                    paramOrder = category.Order,               
                    paramDescription = category.Description,   
                    paramFeatured = category.Featured
                },
                new
                {
                    paramId = category2.Id,                     
                    paramTitle = category2.Title,               
                    paramUrl = category2.Url,                   
                    paramSummary = category2.Summary,           
                    paramOrder = category2.Order,               
                    paramDescription = category2.Description,   
                    paramFeatured = category2.Featured
                }
            });
            Console.WriteLine($"{rows} linhas inseridas");
        }
        #endregion

        #region Procedure
        
        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "[spDeleteStudent] @StudentId";
            var pars = new { StudentId = "6bd552ea-7187-4bae-abb6-54e8f8b9f530" };
            var affectedRows = connection.Execute(
                procedure,
                pars,
                commandType: CommandType.StoredProcedure);

            Console.WriteLine($"{affectedRows} linhas afetadas");
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            var courses = connection.Query(
                procedure,
                pars,
                commandType: CommandType.StoredProcedure);

            foreach (var item in courses)
            {
                Console.WriteLine(item.Title);
            }
        }
        #endregion

        #region Scalar
         static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Categoria();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"
                INSERT INTO 
                    [Category] 
                OUTPUT inserted.[Id]
                VALUES(
                    NEWID(), 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured) 
                ";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"A categoria inserida foi: {id}");
        }
        #endregion
       
    }
}
