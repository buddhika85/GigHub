using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    // Following an artist
    public class Following
    {
        // Composite Primary Keys, using foreign keys
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ArtistId { get; set; }

        //Navigationl properties
        public ApplicationUser User { get; set; }
        public ApplicationUser Artist { get; set; }
    }

}