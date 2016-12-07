using AutoMapper;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        readonly ApplicationDbContext _dbContext;

        public GigsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }


        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Save(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _dbContext.Genres;
                return View(nameof(Create), viewModel);
            }

            if (viewModel.Id != 0)
            {
                var gig = _dbContext.Gigs.Single(g => g.Id == viewModel.Id);
                Mapper.Map<GigFormViewModel, Gig>(viewModel, gig);
                gig.DateTime = viewModel.DateTime;
            }
            else
            {
                var gig = new Gig();
                Mapper.Map<GigFormViewModel, Gig>(viewModel, gig);
                gig.ArtistId = User.Identity.GetUserId();
                gig.DateTime = viewModel.DateTime;
                _dbContext.Gigs.Add(gig);
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}