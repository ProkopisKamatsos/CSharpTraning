using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services;

public class DepartmentService
{
    private readonly DepartmentRepository _departmentRepo;
    private readonly EmployeeRepository _employeeRepo;

    public DepartmentService(DepartmentRepository departmentRepo, EmployeeRepository employeeRepo)
    {
        _departmentRepo = departmentRepo;
        _employeeRepo = employeeRepo;
    }
    public List<Department> GetAllDepartments()
    {
        return _departmentRepo.GetAll();
    }

    public Department CreateDepartment(Department department)
    {
        if (string.IsNullOrWhiteSpace(department.Name))
            throw new Exception("Department name is required");

        department.Name = department.Name.Trim();

        if (_departmentRepo.ExistsByName(department.Name))
            throw new Exception("Department name already exists");

        department.Location ??= "";

        return _departmentRepo.Insert(department);
    }
    public Department UpdateDepartment(Department department)
    {
        if (department.Id <= 0)
            throw new Exception("Invalid department Id");

        var existing = _departmentRepo.GetById(department.Id);
        if (existing is null)
            throw new Exception("Department not found");

        if (string.IsNullOrWhiteSpace(department.Name))
            throw new Exception("Department name is required");

        department.Name = department.Name.Trim();
        department.Location ??= "";

        if (_departmentRepo.ExistsByName(department.Name, department.Id))
            throw new Exception("Department name already exists");

        return _departmentRepo.Update(department);
    }

    public void DeleteDepartment(int id)
    {
        if (id <= 0)
            throw new Exception("Invalid department Id");

        var dept = _departmentRepo.GetById(id);
        if (dept is null)
            throw new Exception("Department not found");

        if (_employeeRepo.AnyInDepartment(id))
            throw new Exception("Cannot delete department because it has active employees");

        _departmentRepo.Delete(id);
    }
}
