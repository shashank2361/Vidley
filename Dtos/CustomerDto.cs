using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string City { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

   //     [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
   //         ApplyFormatInEditMode = true)]
   //     [Min18YearsIFAMember]
        public DateTime? BirthDate { get; set; }

    }
}