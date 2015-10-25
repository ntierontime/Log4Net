using System;
using System.Collections.Generic;
using System.Globalization;

namespace Framework
{
    public class RegisterModel
    {
#if WINDOWS_PHONE
#else
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Display(Name = "User name")]
#endif
        public string UserName { get; set; }

#if WINDOWS_PHONE
#else
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Email address")]
#endif
        public string Email { get; set; }

#if WINDOWS_PHONE
#else
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Password")]
#endif
        public string Password { get; set; }

#if WINDOWS_PHONE
#else
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
#endif
        public string ConfirmPassword { get; set; }
    }
}