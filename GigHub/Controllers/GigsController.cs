﻿using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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
        [ValidateAntiForgeryToken]
        public ActionResult Save(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _dbContext.Genres;
                return View(nameof(Create), viewModel);
            }

            var userId = User.Identity.GetUserId();

            // Edit
            if (viewModel.Id != 0)
            {

                var gig = _dbContext.Gigs.Single(g => g.Id == viewModel.Id);
                gig.ArtistId = userId;
                gig.DateTime = viewModel.GetDateTime();
                gig.Venue = viewModel.Venue;
                gig.GenreId = viewModel.GenreId;
                _dbContext.Gigs.Add(gig);
            }
            else
            {
                var gig = new Gig
                {
                    ArtistId = userId,
                    DateTime = viewModel.GetDateTime(),
                    Venue = viewModel.Venue,
                    GenreId = viewModel.GenreId
                };
                _dbContext.Gigs.Add(gig);
            }

            _dbContext.SaveChanges();
            return RedirectToAction(nameof(GetMyUpcomingGigs), "Gigs");
        }

        [Authorize]
        [HttpGet]
        public ActionResult GigsUserAttending()
        {
            var userId = User.Identity.GetUserId();

            var gigsViewModel = new GigsViewModel
            {
                Gigs = _dbContext.Attendance
                        .Where(a => a.AttendeeId == userId)
                        .Select(a => a.Gig)
                        .Include(g => g.Artist)
                        .Include(g => g.Genre)
                        .ToList(),
                ShowActions = true,
                Heading = "Gigs Im Attending"
            };

            return View("_GigListPartial", gigsViewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ArtistsUserFollowing()
        {
            var userId = User.Identity.GetUserId();
            var artists = from a in _dbContext.Following
                          .Include(a => a.Artist)
                          where a.UserId == userId
                          select a.Artist;
            return View(artists);
        }


        [Authorize]
        [HttpGet]
        public ActionResult GetMyUpcomingGigs()
        {
            var userId = User.Identity.GetUserId();
            var myGigs = (from g in _dbContext.Gigs
                          .Include(global => global.Genre)
                          where g.ArtistId == userId
                          && g.DateTime > DateTime.Now
                          select g)
                         .ToList();
            return View(myGigs);
        }
    }
}