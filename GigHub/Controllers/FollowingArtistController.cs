using GigHub.Dto;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingArtistController : ApiController
    {
        ApplicationDbContext _context;

        public FollowingArtistController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult FollowArtist(FollowArtistDto follow)
        {
            if (follow == null)
                return BadRequest("Artist is not selected");

            var userId = User.Identity.GetUserId();
            if (_context.Following.Any(f => f.UserId == userId && f.ArtistId == follow.ArtistId))
                return BadRequest("User already follows this artist");

            var following = new Following
            {
                ArtistId = follow.ArtistId,
                UserId = userId
            };
            _context.Following.Add(following);
            _context.SaveChanges();
            return Ok("User follows the artist now");
        }
    }
}
