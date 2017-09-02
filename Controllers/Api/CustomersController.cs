﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidley.Dtos;
using Vidley.Models;

namespace Vidley.Controllers.Api

{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
                _context = new ApplicationDbContext();
        }

        // Get /api/customers/
        public IEnumerable<CustomerDto> GetCustmers()
        {
            return _context.Customers.ToList().Select(Mapper.Map <Customer, CustomerDto>);
        }

        //Get /api/customerDto/1
        // similar to details
        //
        //public Customer GetCustomer(int Id) -- THIS WAS BEFORE MAPPING
        public CustomerDto GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer,CustomerDto>(customer);
            //return customerDto;
        }

        //Post /api/customers/
        // similar to Save
        [HttpPost]
        //public Customer PostCustomer(Customer customerDto)
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            // this time the Id property will be set generated by the database object
            //return customerDto;

            customerDto.Id = customer.Id;
            return customerDto;
        }

        // PUT / api/customers/1
        // simliar to 
        [HttpPut]
        //        public void UpdateCustomer(int id, Customer customerDto)

        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerIndb = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customerIndb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            Mapper.Map(customerDto, customerIndb);
            /*customerIndb.Name = customer.Name;
            customerIndb.BirthDate = customer.BirthDate;
            customerIndb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerIndb.BirthDate = customer.BirthDate;
            customerIndb.MembershipTypeId = customer.MembershipTypeId;*/
            // use automapper tool to automatically map the filelds
            _context.SaveChanges();

        }
        //Delete /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerIndb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerIndb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            _context.Customers.Remove(customerIndb);
            _context.SaveChanges();
        }
    }
}
