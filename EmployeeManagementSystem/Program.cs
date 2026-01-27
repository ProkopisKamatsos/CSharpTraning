using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

var cs = "Server=localhost\\SQLEXPRESS;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;";

var factory = new DbConnectionFactory(cs);

var employeeRepo = new EmployeeRepository(factory);
var departmentRepo = new DepartmentRepository(factory);

var employeeService = new EmployeeService(employeeRepo, departmentRepo);

Console.Write("First name: ");
var firstName = Console.ReadLine();

Console.Write("Last name: ");
var lastName = Console.ReadLine();

Console.Write("Email: ");
var email = Console.ReadLine();

Console.Write("Department Id: ");
int.TryParse(Console.ReadLine(), out int departmentId);

Console.Write("Salary: ");
decimal.TryParse(Console.ReadLine(), out decimal salary);
var employee = new Employee
{
    FirstName = firstName ?? "",
    LastName = lastName ?? "",
    Email = email ?? "",
    DepartmentId = departmentId,
    Salary = salary,
    HireDate = DateTime.Now,
    IsActive = true
};
try
{
    var createdEmployee = employeeService.CreateEmployee(employee);
    Console.WriteLine($"Employee created with Id: {createdEmployee.Id}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

