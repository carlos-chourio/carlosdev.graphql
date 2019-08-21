using Carlosdev.GraphQL.Types;
using Carlosdev.Posts;
using GraphQL.Types;
using System;
using System.Linq;

namespace Carlosdev.GraphQL {
    public class CarlosdevQuery : ObjectGraphType {
        private QueryArguments QueryArguments { get;set; }

        public CarlosdevQuery() {
            QueryArguments = CreateQueryArguments();
        }

        public CarlosdevQuery(PostRepository postRepository) {
            Field<ListGraphType<PostType>>("Posts", "Returns Posts",
                resolve: t => postRepository.GetPosts().ToList());
            Field<PostType>("Post","Return a Post corresponding to the given id",
                QueryArguments,
                resolve: t => postRepository.GetPost((Guid)t.Arguments["id"]));
        }

        private QueryArguments CreateQueryArguments() {
            var queryArguments = new QueryArguments();
            queryArguments.Add(CreateQueryArgument<int>("id", "Identity of the entity"));
            return queryArguments;
        }

        private QueryArgument CreateQueryArgument<TType>(string name, string description = "") {
            var queryArgument = new QueryArgument(typeof(TType));
            queryArgument.Name = name;
            queryArgument.Description = description;
            return queryArgument;
        }
    }
}
