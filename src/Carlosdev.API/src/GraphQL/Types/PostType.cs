using Carlosdev.Domain.Comment;
using Carlosdev.Domain.Post;
using GraphQL.Types;

namespace Carlosdev.GraphQL.Types {
    public class PostType : ObjectGraphType<Post> {
        public PostType(CommentFactory commentFactory) {
            Field(f => f.Id).Description("The Identifier of the Post");
            Field(f => f.Title).Description("The Title of the Post");
            Field(f => f.Content).Description("The Content of the Post");
            Field(f => f.PublicationDate).Description("The Publication date of the Post");
            Field(f => f.Rating).Description("The Rating (5 based) of the Post");
            Field<CategoryType>("Category", "The category of the Post");
            Field<UserType>("Author", "Author of the post");
            Field<ListGraphType<CommentType>>(
                "Comments", 
                resolve: context => commentFactory.GetComments(context.Source.Id));
        }
    }
}
