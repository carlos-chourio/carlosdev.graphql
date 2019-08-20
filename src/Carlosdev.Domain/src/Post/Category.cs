using System.ComponentModel;

namespace Carlosdev.Domain.Post {
    public enum Category {
        Technology,
        [Description(".NET")]
        Dotnet,
        [Description("Web Development")]
        WebDevelopment,
        WPF,
        FrontEnd,
        BackEnd,
        GraphQL
    }
}
