using Dapper;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Data;

public class ProjectRepository
{
    private readonly DbConnectionFactory _factory;

    public ProjectRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public List<Project> GetAll()
    {
        using var conn = _factory.CreateConnection();
        var sql = @"
            SELECT Id, Name, StartDate, EndDate, Budget
            FROM Projects
            ORDER BY Id
        ";
        return conn.Query<Project>(sql).ToList();
    }

    public Project? GetById(int id)
    {
        using var conn = _factory.CreateConnection();
        var sql = @"
            SELECT Id, Name, StartDate, EndDate, Budget
            FROM Projects
            WHERE Id = @Id
        ";
        return conn.QuerySingleOrDefault<Project>(sql, new { Id = id });
    }

    public Project Insert(Project project)
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
            INSERT INTO Projects (Name, StartDate, EndDate, Budget)
            VALUES (@Name, @StartDate, @EndDate, @Budget);

            SELECT CAST(SCOPE_IDENTITY() AS int);
        ";

        var id = conn.ExecuteScalar<int>(sql, project);
        project.Id = id;
        return project;
    }

    public Project Update(Project project)
    {
        using var conn = _factory.CreateConnection();

        var sql = @"
            UPDATE Projects
            SET
                Name = @Name,
                StartDate = @StartDate,
                EndDate = @EndDate,
                Budget = @Budget
            WHERE Id = @Id
        ";

        conn.Execute(sql, project);
        return project;
    }

    public void Delete(int id)
    {
        using var conn = _factory.CreateConnection();
        var sql = "DELETE FROM Projects WHERE Id = @Id";
        conn.Execute(sql, new { Id = id });
    }

    public bool ExistsByName(string name)
    {
        using var conn = _factory.CreateConnection();
        var sql = "SELECT COUNT(1) FROM Projects WHERE Name = @Name";
        return conn.ExecuteScalar<int>(sql, new { Name = name }) > 0;
    }

    public bool ExistsByName(string name, int excludeId)
    {
        using var conn = _factory.CreateConnection();
        var sql = "SELECT COUNT(1) FROM Projects WHERE Name = @Name AND Id <> @ExcludeId";
        return conn.ExecuteScalar<int>(sql, new { Name = name, ExcludeId = excludeId }) > 0;
    }
}
