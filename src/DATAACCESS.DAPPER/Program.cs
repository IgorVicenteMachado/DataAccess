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
            
            using (var connection = new SqlConnection(CONNECTION_STRING) )
            {
                var categories = connection.Query<Category>("select [Id], [title] from [category] order by [Title];");

                foreach(var category in categories)
                {
                    Console.WriteLine($"{category.Id} | {category.Title}");
                }
            }
        }
    }
}
