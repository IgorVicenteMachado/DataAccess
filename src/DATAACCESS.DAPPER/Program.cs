using System;
using Dapper;
using DATAACCESS.DAPPER.Models;
using Microsoft.Data.SqlClient;

namespace DATAACCESS.DAPPER
{
    class Program
    {
        private const string CONNECTION = 
            @"Server = localhost,1433; Database=praticandodb; User ID=sa; password=!@#$%12345;TrustServerCertificate=True";

        static void Main(string[] args)
        {
             using (var connection = new SqlConnection(CONNECTION))
            {

              
            }
        }
    }
}
