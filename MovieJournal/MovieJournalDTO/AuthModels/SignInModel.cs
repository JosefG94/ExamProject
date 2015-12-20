using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO.AuthModels
{
    public class SignInModel
    {
        [Required, MaxLength(16, ErrorMessage = "User name must be 3-16 characters"), MinLength(3, ErrorMessage = "User name must be minimum 3-16 characters"), Display(Name = "User name")]
        public string UserName{ get; set; }

        [Required]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string NoMatch { get; set; }
    }
}
