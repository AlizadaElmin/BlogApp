using Microsoft.AspNetCore.Http;

namespace BlogApp.BL.Exceptions.UserExceptions;

public class UserAlreadyExistsException:Exception,IBaseException
{
    public int StatusCode => StatusCodes.Status404NotFound;
    public string ErrorMessage { get; }
    
    public UserAlreadyExistsException()
    {
        ErrorMessage="User already exists!";
    }

    public UserAlreadyExistsException(string message):base(message)
    {
        ErrorMessage=message;
    }
}