using Microsoft.Data.SqlClient; 
namespace dataaccess
{
    class Program
    {
        private const string CONNECTION_STRING = 
            @"Server = localhost,1433; Database=praticandodb; User ID=sa; password=!@#$%12345;TrustServerCertificate=True";
            
        static void Main(string[] args)
        {
             using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                Console.WriteLine("Conectado");
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }
        }
    }
}