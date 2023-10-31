using System.ComponentModel.DataAnnotations;

namespace AspLesson11.Models
{
    public class RegistrationBindingModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
        [Required]
        [UIHint("Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
