using Carlosdev.Security;
using System;

namespace Carlosdev.Domain.Posts {
    public class Post {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public User Author { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime PublicationDate { get; set; }
        public Post() { }
        public Post(Guid id, string title, string content, DateTime publicationDate, int rating, Category category, User author) {
            Id = id;
            Title = title;
            Content = content;
            PublicationDate = publicationDate;
            Rating = rating;
            Category = category;
            Author = author;
        }
    }
}
