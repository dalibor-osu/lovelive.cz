namespace LoveLiveCZ.Validation;

public class ValidationResult
{
    public List<ValidationError> Errors { get; set; } = new();
    public bool IsValid => !Errors.Any();
}