using Dapper;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data;

public class DepartmentRepository
{
    private readonly DbConnectionFactory _factory;

    public DepartmentRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public bool Exists(int departmentId)
    {
        using var conn = _factory.CreateConnection();
        var sql = "SELECT COUNT(1) FROM Departments WHERE Id = @Id";
        return conn.ExecuteScalar<int>(sql, new { Id = departmentId }) > 0;
    }
    public Department? GetById(int id)
    {
        using var conn = _factory.CreateConnection();
        var sql = @"
        SELECT Id, Name, Location, ManagerId
        FROM Departments
        WHERE Id = @Id
    ";
        return conn.QuerySingleOrDefault<Department>(sql, new { Id = id });
    }
    public bool ExistsByName(string name, int excludeId)
    {
        using var conn = _factory.CreateConnection();
        var sql = "SELECT COUNT(1) FROM Departments WHERE Name = @Name AND Id <> @ExcludeId";
        return conn.ExecuteScalar<int>(sql, new { Name = name, ExcludeId = excludeId }) > 0;
    }

    public void Delete(int id)
    {
        using var conn = _factory.CreateConnection();
        var sql = "DELETE FROM Departments WHERE Id = @Id";
        conn.Execute(sql, new { Id = id });
    }
    public bool ExistsByName(string name)
    {
        using var conn = _factory.CreateConnection();
        var sql = "SELECT COUNT(1) FROM Departments WHERE Name = @Name";
        return conn.ExecuteScalar<int>(sql, new { Name = name }) > 0;
    }
    public List<Department> GetAll()
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
        SELECT Id, Name, Location, ManagerId
        FROM Departments
        ORDER BY Name
    ";

        return conn.Query<Department>(sql).ToList();
    }


    public Department Update(Department department)
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
        UPDATE Departments
        SET
            Name = @Name,
            Location = @Location,
            ManagerId = @ManagerId
        WHERE Id = @Id
    ";

        conn.Execute(sql, department);
        return department;
    }

    public Department Insert(Department department)
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
        INSERT INTO Departments (Name, Location, ManagerId)
        VALUES (@Name, @Location, @ManagerId);

        SELECT CAST(SCOPE_IDENTITY() AS int);
    ";

        var id = conn.ExecuteScalar<int>(sql, department);
        department.Id = id;
        return department;
    }

}
