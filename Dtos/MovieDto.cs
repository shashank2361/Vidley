using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.Dtos
{
    public class MovieDto
    {


        public int Id { get; set; }
        public string Name { get; set; }
     
        [Required]
        public byte GenreId { get; set; }
  
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
      
        [Range(1, 20)]
        public short NumberInStock { get; set; }
    }
}