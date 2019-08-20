using GraphQL;
using GraphQL.Types;

namespace Carlosdev.GraphQL {
    public class CarlosdevSchema : Schema {
        public CarlosdevSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver) {
            Query = dependencyResolver.Resolve<CarlosdevQuery>();
        }
    }
}
