using GigHub.Models;
using GigHub.Models.CustomValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

        public string ArtistId { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        // Foreign key
        [Display(Name = nameof(Genre))]
        [Required]
        public byte GenreId { get; set; }

        // drop downmenu
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            //return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            //string date = "13/02/09";
            //string time = "2:35:10 PM";

            return DateTime.ParseExact(Date + " " + Time, "dd/MM/yy h:mm:ss tt", CultureInfo.InvariantCulture);
        }
    }
}