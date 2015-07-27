using RecipeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeManagement.Repository
{
    public class InMemoryRecipeRepository : IRepository<Recipe>
    {
        private IDictionary<int, Recipe> _recipes = new Dictionary<int, Recipe>
        {
            { 1, new Recipe(1, "Honey Lime Sriracha Chicken", "http://www.handletheheat.com/honey-lime-sriracha-chicken/") }
        };
        private int _idCount = 1;
        private object _lock = new object();

        public Task<int> Add(Recipe item)
        {
            int id;
            lock (_lock)
                id = ++_idCount;

            _recipes.Add(id, new Recipe(id, item.Title, item.Link, item.Description));
            return Task.FromResult(id);
        }

        public Task<IEnumerable<Recipe>> GetAll()
        {
            return Task.FromResult(_recipes.Values.AsEnumerable());
        }

        public Task<Recipe> GetById(int id)
        {
            Recipe recipe = null;
            _recipes.TryGetValue(id, out recipe);
            return Task.FromResult(recipe);
        }

        public Task<bool> TryDelete(int id)
        {
            if (_recipes.ContainsKey(id))
            {
                return Task.FromResult(_recipes.Remove(id));
            }
            return Task.FromResult(false);
        }

        public void Update(int id, Recipe recipe)
        {
            if (_recipes.ContainsKey(id))
            {
                _recipes[id] = recipe;
            }
            else
            {
                _recipes.Add(id, recipe);
            }
        }
    }
}
