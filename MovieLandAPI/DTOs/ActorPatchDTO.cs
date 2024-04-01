using System.ComponentModel.DataAnnotations;

namespace MovieLandAPI.DTOs
{
    public class ActorPatchDTO
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
