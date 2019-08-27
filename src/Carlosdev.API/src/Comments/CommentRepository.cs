using Carlosdev.Persistence;
using System.Threading.Tasks;
using System.Linq;
using System;
using Carlosdev.Domain.Comment;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Carlosdev.Comments {
    public class CommentRepository {
        private readonly CarlosdevDbContext context;

        public CommentRepository(CarlosdevDbContext context) {
            this.context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync() {
            var comments =context.Comment;
            return await comments.ToListAsync();
        }

        public async Task<IDictionary<Guid, IEnumerable<Comment>>> GetCommentsByPostIds(IEnumerable<Guid> postIds) {
            var comments = await context.Comment.Where(c => postIds.Contains(c.PostId)).ToListAsync();
            var result = comments.ToLookup(t => t.PostId)
            .ToDictionary(t => t.Key, t=> t.AsEnumerable());
            return result; //Task.FromResult((IDictionary<Guid,IEnumerable<Comment>>)comments);
        }
    }
}
