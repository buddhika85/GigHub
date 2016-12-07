using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        // Foreign key
        public string ArtistId { get; set; }

        // Navigation peroperty
        public ApplicationUser Artist { get; set; }

        public DateTime? DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }


        // Foreign key
        [Required]
        public byte GenreId { get; set; }

        // Navigation peroperty
        public Genre Genre { get; set; }


    }
}