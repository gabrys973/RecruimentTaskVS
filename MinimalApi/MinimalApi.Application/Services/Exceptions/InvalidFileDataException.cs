namespace MinimalApi.Application.Services.Exceptions;

public class InvalidFileDataException : Exception
{
    public InvalidFileDataException() : base("Invalid file data.")
    {
    }
}