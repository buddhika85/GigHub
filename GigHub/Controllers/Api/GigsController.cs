using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = (from g in _context.Gigs
                       where !g.IsCancelled
                       && g.Id == id
                       && g.ArtistId == userId
                       select g).SingleOrDefault();

            if (gig == null)
                return NotFound();

            gig.IsCancelled = true;
            _context.SaveChanges();
            return Ok("Cancelled the Gig Successfuly");
        }
    }
}
