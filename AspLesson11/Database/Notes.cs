using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspLesson11.Database
{
    public class Notes
    {
        [Key]
        public int NoteId { get; set; }
        public string Note { get; set; }

        public int UserId { get; set; }
    }
}
