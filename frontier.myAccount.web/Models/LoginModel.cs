using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace frontier.myAccount.web.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Username should be between 8 and 25 characters")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 2, ErrorMessage = "Password should be between 6 and 12 characters")]
        // [RegularExpression(15, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 18 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}