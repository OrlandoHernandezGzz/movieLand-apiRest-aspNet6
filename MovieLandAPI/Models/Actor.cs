﻿using System.ComponentModel.DataAnnotations;

namespace MovieLandAPI.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Photo { get; set; }
    }
}
