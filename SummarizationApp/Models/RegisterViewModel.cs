using System.ComponentModel.DataAnnotations;

namespace SummarizationApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Required To Agree")]
        public bool IsAgree { get; set; }
    }
}
