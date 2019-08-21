using System;

namespace Carlosdev.Domain.Comment {
    public class Comment {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
