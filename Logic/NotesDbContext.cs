using Microsoft.EntityFrameworkCore;

namespace NoteWriter.Logic
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {

        }
        public DbSet<NoteObject> Notes { get; set; }
    }
}
