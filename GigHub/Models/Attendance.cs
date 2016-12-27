using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    // intermediate entity/table to manage M : M relationship and normalize
    public class Attendance
    {
        // Composite Keys
        [Key]
        [Column(Order = 1)]
        public int GigId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }

        // navigational properties
        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }
    }
}