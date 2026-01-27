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
}
