using EmployeeManagement.models.EmployeeTables;

namespace EmployeeManagement.Service.Interfaces;

public interface IEmployeeService
{
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
    Task<Employee> GetEmployeeById(int employeeId);
    Task<List<Employee>> GetAllEmployees();
}