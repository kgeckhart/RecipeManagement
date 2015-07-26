using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeManagement.Models
{
    public class Recipe
    {
        public Recipe(int id, string title, Uri link, string description = null)
        {
            Id = id;
            Title = title;
            Description = description;
            Link = link;
        }
        public int Id { get; }
        [Required]
        public string Title { get; }
        public string Description { get; }
        [Required]
        public Uri Link { get; }
    }
}
