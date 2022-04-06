# DataAccess [ Acesso a dados com .NET ]

Acesso puro ao banco de dados: 

1. opção 1:
  var connection = new SqlConnection();
            connection.Open();
                //acesso ao banco de dados
            connection.Close();
            
2. opção 2: 
            using (var connection = new SqlConnection())
            {
                //acesso ao banco de dados
            }

> Bibliotecas necessárias
 - adicionando: 
'dotnet add package microsoft.Data.SqlClient --version x.x.x'
 - removendo: 
'dotnet remove package microsoft.Data.SqlClient'
