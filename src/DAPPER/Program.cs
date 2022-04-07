using System;

namespace dataaccess.src.dapper
{
    class Program
    {
        private const string CONNECTION_STRING = 
            @"Server = localhost,1433; Database=praticandodb; User ID=sa; password=!@#$%12345;TrustServerCertificate=True";
            
        static void Main(string[] args)
        {
            Console.Write("Start");
        }
    }
}