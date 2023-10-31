using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspLesson11.Database
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
