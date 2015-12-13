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
        [Required, MaxLength(256), Display(Name = "User name")]
        public string UserName { get; set; }

        [Required, MaxLength(128), Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, MaxLength(128), Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required, MaxLength(100), MinLength(6)]
        public string Password { get; set; }

        [Required, Compare("Password"), Display(Name = "Password (again)")]
        public string ConfirmPassword { get; set; }
    }
}
