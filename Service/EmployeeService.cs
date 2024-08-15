using EmployeeManagement.Context;
using EmployeeManagement.models.EmployeeTables;
using EmployeeManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Service;

public class EmployeeService(MyIdentityDbContext dbContext) : IEmployeeService
{
    public async Task AddEmployeeAsync(Employee employee)
    {
        await dbContext.Employees.AddAsync(employee);
        await dbContext.SaveChangesAsync();
    }

    public Task UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployee(string employeeId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployee(int employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<Employee> GetEmployeeById(int employeeId)
    {
        Employee? employee = await dbContext.Employees.FindAsync(employeeId);
        if (employee is null) throw new InvalidOperationException("Employee not found");
        return employee;
    }

    public Task<List<Employee>> GetAllEmployees()
    {
        throw new NotImplementedException();
    }
}