using Carlosdev.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carlosdev.Domain.Post {
    public class Post {
        public int Id { get; set; }
        public string Title { get; set; }
        public User Author { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime PublicationDate { get; set; }
        public Post(int id, string title, string content, DateTime publicationDate, int rating, Category category, User author) {
            Id = id;
            Title = title;
            Content = content;
            PublicationDate = publicationDate;
            Rating = rating;
            Category = category;
            Author = author;
        }
    }

    public class PostFactory {
        public Post GetPost(int id) {
            return GetPosts().First(t => t.Id == id);
        }

        public IList<Post> GetPosts() {
            User author = new User()
            {
                Id = new Random().Next(100),
                FirstName = "Carlos",
                UserName = "Carlos.Chourio",
                LastName = "Chourio",
                Email = "carlos18daniel@gmail.com",
                Password = "123456789",
            };
            return new List<Post>(new Post[] {
                new Post(new Random().Next(100), "My First Post", "It's not so extensive", DateTime.Today.AddDays(-15),3,Category.BackEnd, author),
                new Post(new Random().Next(100), "My Second Post", "This one neither", DateTime.Today.AddDays(-10),4,Category.Dotnet, author),
                new Post(new Random().Next(100), "My Third Post", "This is a better one but not too long either.", DateTime.Today,5,Category.GraphQL, author)
            });
        }
    }
}
