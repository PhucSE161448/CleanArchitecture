using FluentValidation.Results;

namespace CleanArchitecture.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = new();
        foreach (var err in validationResult.Errors)
        {
            ValidationErrors.Add(err.ErrorMessage);
        }
    }
    public List<string> ValidationErrors { get; set; }
}