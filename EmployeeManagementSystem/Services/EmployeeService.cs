using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

public class EmployeeService
{
    private readonly EmployeeRepository _employeeRepository;
    private readonly DepartmentRepository _departmentRepository;

    public EmployeeService(
        EmployeeRepository employeeRepository,
        DepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    public Employee CreateEmployee(Employee employee)
    {
       
        if (string.IsNullOrWhiteSpace(employee.FirstName))
            throw new Exception("First name is required");

        if (string.IsNullOrWhiteSpace(employee.LastName))
            throw new Exception("Last name is required");

        if (string.IsNullOrWhiteSpace(employee.Email) || !employee.Email.Contains("@"))
            throw new Exception("Invalid email");

        if (employee.Salary < 0)
            throw new Exception("Salary cannot be negative");

        if (!_departmentRepository.Exists(employee.DepartmentId))
            throw new Exception("Department does not exist");

        return _employeeRepository.Insert(employee);
    }

}
