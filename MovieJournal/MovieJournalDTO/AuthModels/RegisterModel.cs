using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO.AuthModels
{
    public class RegisterModel
    {
        [Required, MaxLength(16, ErrorMessage = "User name must be 3-16 characters"), MinLength(3,ErrorMessage = "User name must be minimum 3-16 characters"),Display(Name = "User name")]
        public string UserName { get; set; }

        [Required, MaxLength(20, ErrorMessage ="First name must be 1-20 characters"), MinLength(1, ErrorMessage = "First name must be 1-20 characters"), Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Last name must be 1-20 characters"), MinLength(1, ErrorMessage = "Last name must be 1-20 characters"), Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required, MaxLength(20, ErrorMessage ="Password must be 6-20 characters"), MinLength(6, ErrorMessage = "Password must be 6-20 characters")]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage ="The passwords do not match"), Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
        // Used when register fails (and is not caused by invalid modelstate) to output a user name already has been taken
        public string Taken { get; set; }
    }
}
