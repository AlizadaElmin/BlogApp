using Microsoft.AspNetCore.Http;

namespace BlogApp.BL.Exceptions.UserExceptions;

public class UserNotFound:Exception,IBaseException
{
    public int StatusCode => StatusCodes.Status404NotFound;
    public string ErrorMessage { get; }
    
    public UserNotFound()
    {
        ErrorMessage="User not found!";
    }

    public UserNotFound(string message):base(message)
    {
        ErrorMessage=message;
    }
}
