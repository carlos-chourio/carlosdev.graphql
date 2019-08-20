using Carlosdev.Security;
using GraphQL.Types;

namespace Carlosdev.GraphQL.Types {
    public class UserType : ObjectGraphType<User> {
        public UserType() {
            Field(f => f.UserName);
            Field(f => f.Email);
        }
    }
}
