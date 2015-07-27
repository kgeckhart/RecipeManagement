using Nest;
using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeManagement.Models
{
    [ElasticType(
        Name = "recipe"
    )]
    public class Recipe
    {
        public Recipe(int id, string title, string link, string description = null)
        {
            Id = id;
            Title = title;
            Description = description;
            Link = link;
        }

        public int Id { get; }
        [Required]
        [ElasticProperty(Type = FieldType.String)]
        public string Title { get; }
        [ElasticProperty(Type = FieldType.String)]
        public string Description { get; }
        [Required]
        [ElasticProperty(Index = FieldIndexOption.No)]
        public string Link { get; }
    }
}
