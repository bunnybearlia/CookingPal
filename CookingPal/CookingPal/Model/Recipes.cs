using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookingPal.Model
{
    [Table("Recipes")]
    public class Recipes
    {
        [PrimaryKey, AutoIncrement]
        [Column("ID")]
        public int Id { get; set; }

        [Column("RecipeName")]
        public string RecipeName { get; set; }

        [Column("RecipeInstructions")]
        public string RecipeInstructions { get; set; }

        [Column("Category")]
        public string Category { get; set; }

        // This is the actual column saved in the DB
        [Column("Ingredients")]
        public string IngredientsString { get; set; }

        // This is ignored by SQLite and used only in your code
        [Ignore]
        public List<string> Ingredients
        {
            get => IngredientsString?.Split(',').Select(i => i.Trim()).ToList() ?? new List<string>();
            set => IngredientsString = string.Join(",", value);
        }
    }
}
