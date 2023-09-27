using LoveLiveCZ.Models.Database.Models;
using LoveLiveCZ.Models.DataTransferObjects;
using LoveLiveCZ.Utilities.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace LoveLiveCZ.Validation;

public class Validator
{
    public ValidationResult Validate(object obj)
    {
        var result = new ValidationResult();
        if (obj is IUsernameable username && !IUsernameable.Validate(username))
        {
            result.Errors.Add(new ValidationError
            {
                PropertyName = nameof(IUsernameable.Username),
                Message = "Invalid username format"
            });
        }

        if (obj is IPasswordCarrier passwordCarrier && !IPasswordCarrier.Validate(passwordCarrier))
        {
            result.Errors.Add(new ValidationError
            {
                PropertyName = nameof(IPasswordCarrier.Password),
                Message = "Invalid password format"
            });
        }
        
        if (obj is IEmail email && !IEmail.Validate(email))
        {
            result.Errors.Add(new ValidationError
            {
                PropertyName = nameof(IEmail.Email),
                Message = "Invalid email format"
            });
        }
        
        if (obj is IDisplayNameable displayName && !IDisplayNameable.Validate(displayName))
        {
            result.Errors.Add(new ValidationError
            {
                PropertyName = nameof(IDisplayNameable.DisplayName),
                Message = "Invalid displayName format"
            });
        }

        return result;
    }
}