using System.ComponentModel.DataAnnotations;

namespace MovieLandAPI.Validations
{
    public class TypeFileValidation: ValidationAttribute
    {
        private readonly string[] validTypes;

        public TypeFileValidation(string[] validTypes)
        {
            this.validTypes = validTypes;
        }

        public TypeFileValidation(GroupTypeFile groupTypeFile)
        {
            if (groupTypeFile == GroupTypeFile.Image)
            {
                validTypes = new string[] { "image/jpeg", "image/png", "image/gif" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (!validTypes.Contains(formFile.ContentType))
            {
                return new ValidationResult($"El tipo del archivo debe " +
                    $"ser uno de los siguientes: {string.Join(", ", validTypes)}");
            }

            return ValidationResult.Success;
        }

    }
}
