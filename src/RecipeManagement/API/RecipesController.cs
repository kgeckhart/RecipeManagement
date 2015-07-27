using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RecipeManagement.Repository;
using RecipeManagement.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeManagement.API
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private readonly IRepository<Recipe> _recipeRepo;

        public RecipesController(IRepository<Recipe> recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Recipe>> Get()
        {
            return await _recipeRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _recipeRepo.GetById(id);
            if (item == null)
                return HttpNotFound();
            else
                return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Recipe recipe)
        {
            var id = await _recipeRepo.Add(recipe);

            string url = Url.RouteUrl("Get", new { id = id }, Request.Scheme, Request.Host.ToUriComponent());
            Context.Response.StatusCode = 201;
            Context.Response.Headers["Location"] = url;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Recipe recipe)
        {
            _recipeRepo.Update(id, recipe);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _recipeRepo.TryDelete(id))
                return new HttpStatusCodeResult(204);
            else
                return HttpNotFound();
        }
    }
}
