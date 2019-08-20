using Carlosdev.Domain.Post;
using GraphQL.Types;

namespace Carlosdev.GraphQL.Types {
    public class CategoryType : EnumerationGraphType<Category>{
        public CategoryType() {
            Name = "Category";
            Description = "The Category of the post";
        }
    }
}
