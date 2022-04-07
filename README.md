# DataAccess [ Acesso a dados com .NET ]

Acesso puro ao banco de dados: 

1. opção 1: </br>
  var connection = new SqlConnection();</br>
            connection.Open();</br>
                `//acesso ao banco de dados`</br>
            connection.Close();</br>
2. opção 2: </br>
            using (var connection = new SqlConnection())</br>
            {</br>
                `//acesso ao banco de dados`</br>
            }</br>

 > Bibliotecas necessárias


| Tipo | adicionando  | removendo                                             |
|--- | --- | ----------------------------------------------------- |
| ADO | dotnet add package microsoft.Data.SqlClient --version x.x.x  | dotnet remove package microsoft.Data.SqlClient |
|  |   |        |
