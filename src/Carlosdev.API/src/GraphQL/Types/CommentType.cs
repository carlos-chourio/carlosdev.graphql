using Carlosdev.Domain.Comment;
using GraphQL.Types;

namespace Carlosdev.GraphQL.Types {
    public class CommentType : ObjectGraphType<Comment> {
        public CommentType() {
            Field(f => f.Id).Description("Unique Identifier of a comment");
            Field(f => f.Title).Description("Title of the comment");
            Field(f => f.Content);
            Field(f => f.PostId);
            Field(f => f.UserId).Description("Author of the comment");
        }
    }
}
