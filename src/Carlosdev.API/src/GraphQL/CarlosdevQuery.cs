using Carlosdev.Domain.Post;
using Carlosdev.GraphQL.Types;
using GraphQL.Types;
using System;

namespace Carlosdev.GraphQL {
    public class CarlosdevQuery : ObjectGraphType {
        private QueryArguments QueryArguments { get;set; }

        public CarlosdevQuery() {
            QueryArguments = CreateQueryArguments();
        }

        public CarlosdevQuery(PostFactory postFactory) {
            Field<ListGraphType<PostType>>("Posts", "Returns Posts",
                resolve: t => postFactory.GetPosts());
            Field<PostType>("Post","Return a Post corresponding to the given id",
                QueryArguments,
                resolve: t => postFactory.GetPost((int)t.Arguments["id"]));
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
