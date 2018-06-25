﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name="Malavika"},
                new Customer{Name ="Anju"},
                new Customer{ Name="Praveen"}
            };

            var randomMovieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);
        }

      
    }
}