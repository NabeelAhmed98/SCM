using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCM.Data.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }


        
        private ICollection<EmailAddress> _EmailAddress = new List<EmailAddress>();
        [Display(Name = "Email Addresses")]
        public ICollection<EmailAddress> EmailAddresses {
            get { return _EmailAddress; }
            set { _EmailAddress = value; }
        }
    }
}
