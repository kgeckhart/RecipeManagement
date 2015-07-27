using Nest;
using RecipeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagement.Repository
{
    public class ElasticSearchRecipeRepository : IRepository<Recipe>
    {
        private readonly IElasticClient _client;
        public ElasticSearchRecipeRepository()
        {
            _client = new ElasticClient(new ConnectionSettings(new Uri("http://localhost:9200"), "recipes"));
            var settings = new IndexSettings();
            settings.NumberOfReplicas = 1;
            settings.NumberOfShards = 5;

            if (_client.IndexExists("recipes").Exists == false)
            {
                _client.CreateIndex(index => index.Index("recipes")
                    .InitializeUsing(settings)
                    .AddMapping<Recipe>(m => m.MapFromAttributes()));
            }
            if (_client.IndexExists("recipes").Exists == false)
            {
                _client.Map<Recipe>(m => m.MapFromAttributes());
            }
        }

        public async Task<int> Add(Recipe recipe)
        {
            var result = await _client.IndexAsync(recipe);
            if (result.ServerError != null)
                throw new Exception(result.ServerError.Error.ToString());
            return int.Parse(result.Id);
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            var result = await _client.SearchAsync<Recipe>(new SearchRequest());
            return result.Documents;
        }

        public async Task<Recipe> GetById(int id)
        {
            var result = await _client.GetAsync<Recipe>(id);
            return result.Source;
        }

        public async Task<bool> TryDelete(int id)
        {
            var result = await _client.DeleteAsync<Recipe>(id);
            if (result.Found)
                return true;
            else
                return false;
        }

        public void Update(int id, Recipe item)
        {
            throw new NotImplementedException();
        }
    }
}
