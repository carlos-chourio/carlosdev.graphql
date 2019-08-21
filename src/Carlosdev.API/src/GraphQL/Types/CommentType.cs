using Carlosdev.Domain.Comment;
using GraphQL.Types;

namespace Carlosdev.GraphQL.Types {
    public class CommentType : ObjectGraphType<Comment> {
        public CommentType() {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("The Identifier of the Comment");
            Field(f => f.Title).Description("Title of the comment");
            Field(f => f.Content);
            Field(f => f.PostId, type: typeof(IdGraphType));
            Field(f => f.UserId).Description("Author of the comment");
        }
    }
}
