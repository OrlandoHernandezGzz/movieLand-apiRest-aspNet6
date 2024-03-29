using System.ComponentModel.DataAnnotations;

namespace MovieLandAPI.DTOs
{
    public class CreationGenderDTO
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
    }
}
