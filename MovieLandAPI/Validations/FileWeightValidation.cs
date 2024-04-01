using System.ComponentModel.DataAnnotations;

namespace MovieLandAPI.Validations
{
    public class FileWeightValidation: ValidationAttribute
    {
        private readonly int maxWeightInMB;

        public FileWeightValidation(int maxWeightInMB)
        {
            this.maxWeightInMB = maxWeightInMB;
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

            // como length esta en bytes tenemos que multiplicar * 1024 dos veces para convertir los MB a Bytes.
            if (formFile.Length > maxWeightInMB * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe ser mayor a {maxWeightInMB}mb");
            }

            return ValidationResult.Success;
        }
    }
}
