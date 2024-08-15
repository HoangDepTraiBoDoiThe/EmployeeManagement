using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.ApplicationUserTables.DTOs;

public class RegisterRequest
{
    [Required]
    public required string UserName { get; init; }
    
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; init; }

    [EmailAddress] [DataType(DataType.EmailAddress)]
    public required string Email { get; init; }

    [Phone]
    [Required] 
    [DataType(DataType.PhoneNumber)]
    public required string PHoneNumber { get; init; }
    
    [Required]
    [DataType(DataType.Date)]
    public required DateOnly StartDate { get; init; }

    public RegisterRequest()
    {
    }

    public RegisterRequest(string userName, string password, string email, string pHoneNumber, DateOnly startDate)
    {
        UserName = userName;
        Password = password;
        Email = email;
        PHoneNumber = pHoneNumber;
        StartDate = startDate;
    }
}