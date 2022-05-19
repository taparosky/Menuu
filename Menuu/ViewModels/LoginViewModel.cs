using System.ComponentModel.DataAnnotations;

namespace Menuu.ViewModels
{
    public class LoginViewModel
    {   
        [Required(ErrorMessage = "Type the user name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Type the password")]
        [DataType(DataType.Password)]
        [Display (Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
