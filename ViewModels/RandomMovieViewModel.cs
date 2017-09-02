using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Controllers;
using Vidley.Models;


namespace Vidley.ViewModels
{
    public class RandomMovieViewModel
    {
        [Required]
        [StringLength(10)]
        public Movie Movie { get; set; }
        public List<Customer> Customers{ get; set; }
    }
    
}