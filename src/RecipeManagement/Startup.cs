using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Nest;
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
            services.AddSingleton<IRepository<Recipe>, ElasticSearchRecipeRepository>();
            
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            
        }
    }
}
