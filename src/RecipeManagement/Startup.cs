using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using RecipeManagement.Models;
using RecipeManagement.Repository;

namespace RecipeManagement
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(typeof(IRepository<Recipe>), typeof(InMemoryRecipeRepository));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            
        }
    }
}
