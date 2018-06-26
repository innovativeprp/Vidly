using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

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

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return HttpNotFound();
            var customerViewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };
            return View("CustomerForm", customerViewModel);
        }

        public ActionResult New()
        {
            var memebershipTypes = _dbContext.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerViewModel
            {
                MembershipTypes = memebershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm",newCustomerViewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        { 
            if(!ModelState.IsValid)
            {
                var memebershipTypes = _dbContext.MembershipTypes.ToList();
                var newCustomerViewModel = new CustomerViewModel
                {
                    MembershipTypes = memebershipTypes,
                    Customer=customer
                };
                return View("CustomerForm", newCustomerViewModel);
            }
            if (customer.Id == 0)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _dbContext.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
  }
