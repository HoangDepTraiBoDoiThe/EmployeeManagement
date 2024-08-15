using EmployeeManagement.Models.ApplicationUserTables.DTOs;

namespace EmployeeManagement.Service.Interfaces;

public interface IUserService
{
    Task CreateEmployeesAsync(RegisterRequest request);
}