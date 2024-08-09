using EmployeeManagement.Helper;

namespace EmployeeManagement.Models.ApplicationUserTables.DTOs.Auth;

public class LoginResponse(string responseMessage) : GeneralResponse(responseMessage)
{
    public string Token { get; set; }

    public LoginResponse(string responseMessage, string token) : this(responseMessage)
    {
        Token = token;
    }
}