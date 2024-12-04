using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LifeInsuranceApplication.Misc
{
    public class FileRequiredAttribute : ValidationAttribute
    {
        private readonly string[] _validTypes;
        private readonly long _maxSize;

        public FileRequiredAttribute(string[] validTypes, long maxSize)
        {
            _validTypes = validTypes;
            _maxSize = maxSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not IFormFile file)
                return new ValidationResult("File is required.");

            if (file.Length == 0)
                return new ValidationResult("File cannot be empty.");

            if (!_validTypes.Contains(file.ContentType))
                return new ValidationResult("Invalid file type.");

            if (file.Length > _maxSize)
                return new ValidationResult("File size exceeds limit.");

            return ValidationResult.Success;
        }
    }
}
