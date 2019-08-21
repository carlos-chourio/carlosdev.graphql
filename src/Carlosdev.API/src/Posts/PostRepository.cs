using System;
using System.Linq;
using System.Threading.Tasks;
using Carlosdev.Persistence;
using Carlosdev.Domain.Posts;

namespace Carlosdev.Posts {
    public class PostRepository {
        private readonly CarlosdevDbContext context;

        public PostRepository(CarlosdevDbContext context) {
            this.context = context;
        }
        public IQueryable<Post> GetPosts() {
            return context.Post;
        }

        public async Task<Post> GetPost(Guid id) {
            return await context.Post.FindAsync(id);
        }
    }
}
