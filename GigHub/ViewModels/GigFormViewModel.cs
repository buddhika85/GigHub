using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

        public string ArtistId { get; set; }
        public ApplicationUser Artist { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        // Foreign key
        [Display(Name = nameof(Genre))]
        [Required]
        public byte GenreId { get; set; }

        // Navigation peroperty
        public Genre Genre { get; set; }

        // drop downmenu
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime DateTime
        {
            get
            {
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            }
        }
    }
}