using Carlosdev.GraphQL.Types;
using Carlosdev.Posts;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace Carlosdev.GraphQL {
    public class CarlosdevQuery : ObjectGraphType {

        public CarlosdevQuery(PostRepository postRepository) {
            Field<ListGraphType<PostType>>("Posts", "Returns Posts",
                resolve: t => {
                    var x = (ClaimsPrincipal) t.UserContext;
                    // check user.Claims
                    return postRepository.GetPosts().ToListAsync();
                }
            );

            Field<PostType>("Post","Return a Post corresponding to the given id",
                new QueryArguments(new QueryArgument<IdGraphType>() {
                    Name = "id",
                    Description = "Identity of the entity"
                }),
                resolve: t => {
                    var user = (ClaimsPrincipal)t.UserContext;
                    // check user.Claims
                    Guid id = t.GetArgument<Guid>("id");
                    return postRepository.GetPost(id);
                }
            );

        }
    }
}
