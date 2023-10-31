using System.ComponentModel.DataAnnotations;

namespace AspLesson11.Models
{
    public class SignInBindingModel
    {
        [UIHint("Password")]
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
