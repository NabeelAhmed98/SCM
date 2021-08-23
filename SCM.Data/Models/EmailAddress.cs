using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCM.Data.Models
{
    public class EmailAddress
    {
        [Key]
        
        public int EmailAddressId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage ="Required")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Required")]
        [Display(Name = "Email Type")]

        public EmailType EmailType { get; set; }

        public Contact Contact { get; set; }
    }

    public enum EmailType { 
        Personal,
        Business
    }
}