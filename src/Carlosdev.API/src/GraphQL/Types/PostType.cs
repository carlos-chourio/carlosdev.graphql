using Carlosdev.Comments;
using Carlosdev.Domain.Comment;
using Carlosdev.Domain.Posts;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;

namespace Carlosdev.GraphQL.Types {
    public class PostType : ObjectGraphType<Post> {
        public PostType(CommentRepository commentRepository, IDataLoaderContextAccessor dataLoaderAccessor) {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("The Identifier of the Post");
            Field(f => f.Title).Description("The Title of the Post");
            Field(f => f.Content).Description("The Content of the Post");
            Field(f => f.PublicationDate).Description("The Publication date of the Post");
            Field(f => f.Rating).Description("The Rating (5 based) of the Post");
            Field<CategoryType>("Category", "The category of the Post");
            Field<UserType>("Author", "Author of the post");
            Field<ListGraphType<CommentType>>(
                "Comments",
                resolve: context => {
                    var loader = dataLoaderAccessor.Context.GetOrAddBatchLoader<Guid, IEnumerable<Comment>>(
                        "GetCommentsByPostIds", commentRepository.GetCommentsByPostIds);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
