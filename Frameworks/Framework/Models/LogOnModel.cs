using System;
using System.Collections.Generic;
using System.Globalization;

namespace Framework
{
    public class LogOnModel
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
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Password")]
#endif
        public string Password { get; set; }

#if WINDOWS_PHONE
#else
        [System.ComponentModel.DataAnnotations.Display(Name = "Remember me?")]
#endif
        public bool RememberMe { get; set; }
    }
}