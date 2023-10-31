using Microsoft.EntityFrameworkCore;

namespace AspLesson11.Database
{
    public class NoteContext:DbContext
    {
        public DbSet<Notes> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NotesDb;Trusted_Connection=True;");
        }
    }
}
