using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class Min18YearsIFAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is Required");
            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            if ((customer.BirthDate.Value.Month > DateTime.Now.Month) ||
                (customer.BirthDate.Value.Month == DateTime.Now.Month &&
                 customer.BirthDate.Value.Day > DateTime.Now.Day))
                age--;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at leat 18");

        }
    }
}