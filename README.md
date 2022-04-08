# DataAccess [ Acesso a dados com .NET ]

## Acesso puro ao banco de dados: 
https://docs.microsoft.com/pt-br/sql/connect/ado-net/overview-sqlclient-driver?view=sql-server-ver15  


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
 https://docs.microsoft.com/pt-br/dotnet/standard/data/sqlite/dapper-limitations</br>
           
 Utilização de classes [com propriedades] para tipagem e rastreamento pelo dapper. 
 Importante: tipo e nome da propriedade deve ser o mesmo tipo e nome na tabela. Exceção: utilização de alias.

 Segue comparação: </br> 
![tbl](src/img/tblcateg.PNG)
![class](src/img/classcateg.PNG)


 >  OBS: ataque sqlinjection </br>
  
  -  ERRADO ->  `var insertSql = $@"insert into Category values 
                ({category.Id}, {category.Title} , ... )";` [não se pode concatenar, risco ataque] </br>

  -  CORRETO -> `var insertSql = $@"insert into Category values 
                ( @paramId, @paramTitle , @paramUrl, @paramSummary, @paramOrder, @paramDescription, @paramFeatured )";`
      
## 
 > ## Bibliotecas necessárias

| Tipo| adicionando  | removendo                                             |
|---  | --- | ----------------------------------------------------- |
| ADO | dotnet add package microsoft.Data.SqlClient --version x.x.x  | dotnet remove package microsoft.Data.SqlClient |
|  |  |        |
| DAPPER | dotnet add package dapper --version 2.0.90  | dotnet remove package dapper |
| |  | |

OBS: dotnet new console 
