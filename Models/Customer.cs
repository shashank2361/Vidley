using System;
 
using System.ComponentModel.DataAnnotations;

namespace Vidley.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string City { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name= "MemberShipType")]
        public byte MembershipTypeId { get; set; }

        [Display (Name ="Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        [Min18YearsIFAMember]
        public DateTime? BirthDate { get; set; }
    }


}