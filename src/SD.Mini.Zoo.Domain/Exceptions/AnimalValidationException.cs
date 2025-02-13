namespace SD.Mini.Zoo.Domain.Exceptions;

public class AnimalValidationException: Exception
{
    public AnimalValidationException()
    {
    }

    public AnimalValidationException(string? message) : base(message)
    {
    }

    public AnimalValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}