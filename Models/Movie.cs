using System;
 using System.ComponentModel.DataAnnotations;
 

namespace Vidley.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
                ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        // [DisplayFormat(DataFormatString ="{0:dddd, MMMM,yyyy}",
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
                        ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
        [Display ( Name="Number in Stock")]
        [Range(1, 20)]
        public short NumberInStock { get; set; }
    }

    //movies/random 
}