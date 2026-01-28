using System.Data;
using Dapper;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data;

public class EmployeeRepository
{
    private readonly DbConnectionFactory _factory;

    public EmployeeRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public Employee? GetById(int id)
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
        SELECT 
            Id, FirstName, LastName, Email, Phone,
            DepartmentId, Salary, HireDate, IsActive
        FROM Employees
        WHERE Id = @Id
    ";

        return conn.QuerySingleOrDefault<Employee>(sql, new { Id = id });
    }


    public List<Employee> GetAll()
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
        SELECT 
            Id, FirstName, LastName, Email, Phone,
            DepartmentId, Salary, HireDate, IsActive
        FROM Employees
        ORDER BY Id
    ";

        return conn.Query<Employee>(sql).ToList();
    }

    
    public Employee Insert(Employee employee)
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
        INSERT INTO Employees
        (
            FirstName,
            LastName,
            Email,
            Phone,
            DepartmentId,
            Salary,
            HireDate,
            IsActive
        )
        VALUES
        (
            @FirstName,
            @LastName,
            @Email,
            @Phone,
            @DepartmentId,
            @Salary,
            @HireDate,
            @IsActive
        );

        SELECT CAST(SCOPE_IDENTITY() AS int);
    ";

        var id = conn.ExecuteScalar<int>(sql, employee);

        employee.Id = id;
        return employee;
    }
    public Employee Update(Employee employee)
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
        UPDATE Employees
        SET
            FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email,
            Phone = @Phone,
            DepartmentId = @DepartmentId,
            Salary = @Salary,
            IsActive = @IsActive
        WHERE Id = @Id
    ";

        conn.Execute(sql, employee);
        return employee;
    }

    public void SoftDelete(int id)
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
        UPDATE Employees
        SET IsActive = 0
        WHERE Id = @Id
    ";

        conn.Execute(sql, new { Id = id });
    }
    public bool AnyInDepartment(int departmentId)
    {
        using var conn = _factory.CreateConnection();
        var sql = "SELECT COUNT(1) FROM Employees WHERE DepartmentId = @DepartmentId AND IsActive = 1";
        return conn.ExecuteScalar<int>(sql, new { DepartmentId = departmentId }) > 0;
    }


}
