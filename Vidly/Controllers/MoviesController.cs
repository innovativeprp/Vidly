﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            return View(movie);
        }

        [Route("movies/Released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult MoviesByReleaseDate(int year,int month)
        {
            return Content($"Year -{year} : Month -{month}");
        }
    }
}