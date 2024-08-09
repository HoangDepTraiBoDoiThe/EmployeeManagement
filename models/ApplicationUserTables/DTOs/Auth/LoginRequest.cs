namespace EmployeeManagement.DTOs.Auth;

public class LoginRequest
{
    public string UserName { get; set; }
    public string UserPassword { get; set; }

    public LoginRequest(string userName, string userPassword)
    {
        this.UserName = userName;
        this.UserPassword = userPassword;
    }
    public LoginRequest()
    {
    }
}