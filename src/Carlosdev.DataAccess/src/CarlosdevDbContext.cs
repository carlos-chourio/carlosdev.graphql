using Carlosdev.Domain.Comment;
using Carlosdev.Domain.Posts;
using Microsoft.EntityFrameworkCore;

namespace Carlosdev.Persistence {
    public class CarlosdevDbContext : DbContext {
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public CarlosdevDbContext(DbContextOptions options) : base(options) { }
    }
}
