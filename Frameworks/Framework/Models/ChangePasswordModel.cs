using System;
using System.Collections.Generic;
using System.Globalization;

namespace Framework
{
    public class ChangePasswordModel
    {
#if WINDOWS_PHONE
#else
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Current password")]
#endif
        public string OldPassword { get; set; }

#if WINDOWS_PHONE
#else
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [System.ComponentModel.DataAnnotations.Display(Name = "New password")]
#endif
        public string NewPassword { get; set; }

#if WINDOWS_PHONE
#else
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Confirm new password")]
        //[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
#endif
        public string ConfirmPassword { get; set; }
    }
}