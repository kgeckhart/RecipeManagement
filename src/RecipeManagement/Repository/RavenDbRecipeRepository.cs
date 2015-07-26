using RecipeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagement.Repository
{
    public class RavenDbRecipeRepository : IRepository<Recipe>
    {
        public Task<int> Add(Recipe item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TryDelete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Recipe item)
        {
            throw new NotImplementedException();
        }
    }
}
