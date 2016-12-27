using GigHub.Models;
using GigHub.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        public ActionResult Index()
        {
            var viewModel = new GigsViewModel
            {
                Gigs = from g in _dbContext.Gigs
                       .Include(g => g.Artist)
                       .Include(g => g.Genre)
                       where g.DateTime > DateTime.Now
                       select g,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs"
            };
            return View("_GigListPartial", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}