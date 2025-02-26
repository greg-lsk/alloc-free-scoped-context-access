namespace _tempName.Exceptions;


public class InactiveLinkException : Exception
{
    public InactiveLinkException() : base(ExceptionMessages.InactiveLinkDefault) {}
    public InactiveLinkException(string message) : base(message) {}
    public InactiveLinkException(string message,Exception innerException) : base(message, innerException) {}   
}