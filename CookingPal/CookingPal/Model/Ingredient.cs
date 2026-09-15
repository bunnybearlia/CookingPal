using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingPal.Model
{
    [Table("IngredientItem")]
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("ItemName")]
        public string ItemName { get; set; }

        [Column("IsSelected")]
        public bool IsSelected { get; set; }
    }
}
