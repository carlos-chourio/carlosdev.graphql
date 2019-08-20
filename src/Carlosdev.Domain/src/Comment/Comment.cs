using System;
using System.Collections.Generic;

namespace Carlosdev.Domain.Comment {
    public class Comment {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class CommentFactory {
        public IEnumerable<Comment> GetComments(int postId) {
            CreateComment(postId);
            return new List<Comment>()
            {
                CreateComment(postId),
                CreateComment(postId),
                CreateComment(postId),
                CreateComment(postId),
                CreateComment(postId)
            };
        }

        private Comment CreateComment(int postId) {
            return new Comment()
            {
                Id = new Random().Next(100),
                Content = "Loren Ipsum",
                Title = "Loren",
                PostId = postId,
                UserId = new Random().Next(100)
            };
        }
    }

}
