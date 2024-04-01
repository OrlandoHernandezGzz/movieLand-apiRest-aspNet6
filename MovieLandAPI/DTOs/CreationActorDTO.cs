using MovieLandAPI.Validations;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MovieLandAPI.DTOs
{
    public class CreationActorDTO
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [FileWeightValidation(maxWeightInMB: 4)]
        [TypeFileValidation(groupTypeFile: GroupTypeFile.Image)]
        public IFormFile Photo { get; set; }
    }
}
