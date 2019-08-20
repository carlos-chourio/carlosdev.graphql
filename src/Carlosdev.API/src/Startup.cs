using Carlosdev.Domain.Comment;
using Carlosdev.Domain.Post;
using Carlosdev.GraphQL;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carlosdev {
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Synchronous IO to enable the usage of Json.NET by GraphQL
            services.Configure<IISServerOptions>(options => {
                options.AllowSynchronousIO = true;
            });
            services.AddScoped<PostFactory>();
            services.AddScoped<CommentFactory>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<CarlosdevSchema>();
            services.AddGraphQL(t=> t.ExposeExceptions=false)
                    .AddGraphTypes(ServiceLifetime.Scoped)
                    .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            app.UseRouting();
            app.UseGraphQL<CarlosdevSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
