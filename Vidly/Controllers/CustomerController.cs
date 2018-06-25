using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _dbContext;
        public CustomerController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _dbContext.Customers.Include("MembershipType").ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include("MembershipType").SingleOrDefault(c => c.Id == id);
            if (customer == null) return HttpNotFound();
            return View(customer);
        }
    }
  }
