using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudMVCCodeFirst.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please enter your username")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter your passworrd")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please enter your Email")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }

    }
}