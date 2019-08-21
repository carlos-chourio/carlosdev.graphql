using System.ComponentModel;

namespace Carlosdev.Domain.Posts {
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
