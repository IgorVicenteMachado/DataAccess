using Microsoft.Data.SqlClient; 
namespace dataaccess
{
    class Program
    {
        private const string CONNECTION_STRING = 
            @"Server = localhost,1433; Database = balta; User ID = sa; password =@temp;TrustServerCertificate=True";
            
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection())
            {
                //acesso ao banco de dados
            }
        }
    }
}