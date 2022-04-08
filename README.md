# DataAccess [ Acesso a dados com .NET ]

## Acesso puro ao banco de dados: 

ADO (através do SqlClient) - é a base de acesso a dados. Dapper, Entity e outras bibliotecas de acesso a dados fazem uso do ADO.


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

## Dapper: 

 Utilização de classes [com propriedades] para tipagem e rastreamento pelo dapper. 
 Importante: tipo e nome da propriedade deve ser o mesmo tipo e nome contido no db. Exceção: utilização de alias.
![tbl]('src/img/tblcateg.PNG')

 > ## Bibliotecas necessárias

| Tipo| adicionando  | removendo                                             |
|---  | --- | ----------------------------------------------------- |
| ADO | dotnet add package microsoft.Data.SqlClient --version x.x.x  | dotnet remove package microsoft.Data.SqlClient |
|  |https://docs.microsoft.com/pt-br/sql/connect/ado-net/overview-sqlclient-driver?view=sql-server-ver15   |        |
| DAPPER | dotnet add package dapper --version 2.0.90  | dotnet remove package dapper |
| | https://docs.microsoft.com/pt-br/dotnet/standard/data/sqlite/dapper-limitations | |

OBS: dotnet new console 
