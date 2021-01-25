using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignUp.Models
{
    public class SignUpActivity
    {
        [Required(ErrorMessage ="First name is required"), StringLength(26, MinimumLength =2, ErrorMessage="First name must have a minimum length of 2 and maximum length of 26")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required"), StringLength(26, MinimumLength = 2, ErrorMessage = "Last name must have a minimum length of 2 and maximum length of 26")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email address is required"), EmailAddress(ErrorMessage ="Email address must be valid")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "At least one activity is required")]
        public List<string> Activities { get; set; }

        public string Comments { get; set; }
    }
}
