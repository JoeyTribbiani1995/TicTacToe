using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Services;
using TicTacToe.Extensions;
using Microsoft.AspNetCore.Routing;
using TicTacToe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;

namespace TicTacToe
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //.AddDirectoryBrowser();

            services.AddSingleton<IUserService, UserService>();

            //working within URL routing
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // developer can understand HTML, CSS, JS and problems quickly.
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // enable the usage of static content, able to use HTML, CSS, JS and images.
            app.UseStaticFiles();
            //app.UseDirectoryBrowser();

            app.UseWebSockets();

            app.UseCommunicationMiddleware();

            // working within URL routing
            var routeBuidler = new RouteBuilder(app);
            routeBuidler.MapGet("CreateUser", context =>
            {
                var firstName = context.Request.Query["firstname"];
                var lastName = context.Request.Query["lastname"];
                var emailAddress = context.Request.Query["email"];
                var password = context.Request.Query["password"];
                var tempUserModel = new UserModel
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = emailAddress,
                    Password = password
                };

                var userService = context.RequestServices.GetService<IUserService>();
                userService.RegisterUser(tempUserModel);

                return context.Response.WriteAsync($"User {tempUserModel.FirstName} {tempUserModel.LastName} was created ");
            });

            var newUserRoutes = routeBuidler.Build();
            app.UseRouter(newUserRoutes);

            // working within URL rewritting
            var options = new RewriteOptions().AddRewrite("newuser", "/UserRegistration/Index", false);
            app.UseRewriter(options);
            
            // adding error handing
            app.UseStatusCodePages("text/plain", "HTTP error - Status Code: {0}");
            app.UseStatusCodePagesWithRedirects("/error/{0}");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
