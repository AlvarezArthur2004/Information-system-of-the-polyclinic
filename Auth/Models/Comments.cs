using Microsoft.EntityFrameworkCore;

namespace Auth.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string MedicId { get; set; }
        public string PacientId { get; set; }
        public string Rate { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CommentDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public CommentDbContext(DbContextOptions<CommentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
}
