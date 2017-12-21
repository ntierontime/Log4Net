/*
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Log4Net.AspNetMvc40Rasor.Models
{
    public partial class UsersContext : DbContext
    {
        public UsersContext()
            : base("Log4Net")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public partial class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public partial class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Common_UserNameLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public partial class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Common_CurrentPasswordLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "Common_PasswordLengthErrorMessage", ErrorMessageResourceType = typeof(Framework.Resx.UIStringResource))]
        [DataType(DataType.Password)]
        [Display(Name = "Common_NewPasswordLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Common_ConfirmPasswordLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessageResourceName= "Common_ConfirmPasswordNotMatchErrorMessage", ErrorMessageResourceType = typeof(Framework.Resx.UIStringResource))]
        public string ConfirmPassword { get; set; }
    }

    public partial class LoginModel
    {
        [Required]
        [Display(Name = "Common_UserNameLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Common_PasswordLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        public string Password { get; set; }

        [Display(Name = "Account_LogIn_RememberMeText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        public bool RememberMe { get; set; }
    }

    public partial class RegisterModel
    {
        [Required]
        [Display(Name = "Common_UserNameLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "Common_PasswordLengthErrorMessage", ErrorMessageResourceType = typeof(Framework.Resx.UIStringResource))]
        [DataType(DataType.Password)]
        [Display(Name = "Common_PasswordLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Common_ConfirmPasswordLabelText", ResourceType = typeof(Framework.Resx.UIStringResource))]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceName= "Common_ConfirmPasswordNotMatchErrorMessage", ErrorMessageResourceType = typeof(Framework.Resx.UIStringResource))]
        public string ConfirmPassword { get; set; }
    }

    public partial class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
*/

