using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidley.Migrations;
using Vidley.Models;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new  CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                return View("CustomerForm", viewModel);
            }
                var prevCustomer = new Customer();
                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                    //TryUpdateModel(customerInDb, "",new String[]{"Name", "BirthDate"});
                    customerInDb.Name = customer.Name;
                    customerInDb.BirthDate = customer.BirthDate;
                    customerInDb.City = customer.City;
                    customer.MembershipTypeId = customer.MembershipTypeId;
                    customer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    // or can use
                    //Mapper.Map(customer, customerInDb);
                    _context.Customers.Add(customer);


                }
                if (prevCustomer != customer)
                {
                    _context.SaveChanges();

                }
                prevCustomer = customer;
            int lastProductId = _context.Customers.Max(item => item.Id);

            return RedirectToAction("Index", "Customer");

        }
               //if (ModelState.IsValid)
               // {
               // var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
               // return Content("Model StaTE NOT VALID");
               // }


 



        public ActionResult New()
        {
            var membershiptype = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer   = new Customer(),
                MembershipTypes = membershiptype
            };
            return View("CustomerForm",viewModel);
    
        }
        

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();
            //  var customers = _context.Customers.ToList();
            //  var customers = GetCustomers();

            return View(customers);
        }

        // GET: Customer/Details/5

 
        public ActionResult Details(int id)
        {

            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);
            //  var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //  var customer = _context.Customers.ToList();
            //  var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
        
            return View(customer);
             
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
            new Customer { Id = 1, Name = "John Smith" },
            new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }


    
}
