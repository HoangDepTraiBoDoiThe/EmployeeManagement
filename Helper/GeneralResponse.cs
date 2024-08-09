namespace EmployeeManagement.Helper;

public class GeneralResponse(string responseMessage)
{
    public string ResponseMessage { get; set; } = responseMessage;
    
    
}