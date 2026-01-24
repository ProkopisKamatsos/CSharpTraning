using System;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;
using TestCSharp;


    var ConnectionString =
        "Server=localhost\\SQLEXPRESS;Database=DapperTrain;Trusted_Connection=True;TrustServerCertificate=True;";
var sql = "dbo.usp_InsertDapperTest2";
var sql1 = "SELECT * FROM users";
using var connection = new SqlConnection(ConnectionString);
{
    connection.Open();
    //var affectedRows = connection.Execute(sql, new { Username = "kostas", Email = "kostas@test.com"  }, commandType: System.Data.CommandType.StoredProcedure);
    //Console.WriteLine(affectedRows);
    var  users = connection.Query<User>(sql1).ToList();
    //foreach (var user in users)
    //{
    //    Console.WriteLine($"Id: {user.Id}, Username: {user.Username}, Email: {user.Email}");
    //}
}
