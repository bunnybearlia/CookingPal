using CookingPal.Model;
using SQLite;

namespace CookingPal.Service
{
    public class LocalDb
    {
        private const string DB_Name = "Userinfo.db";
        private readonly SQLiteAsyncConnection _connection;
        private bool _isInitialized = false;

        public LocalDb()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_Name));
        }

        private async Task Init()
        {
            if (!_isInitialized)
            {
                await _connection.CreateTableAsync<User>();
                await _connection.CreateTableAsync<Recipes>();
                await _connection.CreateTableAsync<Ingredient>();
                _isInitialized = true;
            }
        }

        public async Task Create(User user)
        {
            await Init();
            await _connection.InsertAsync(user);
        }

        public async Task<User?> GetUserByCredentials(string email, string password)
        {
            await Init();
            var users = await _connection.Table<User>()
                                         .Where(u => u.Email == email && u.Password == password)
                                         .ToListAsync();
            return users.FirstOrDefault();
        }

        public async Task UpdateUser(User user)
        {
            await Init();
            await _connection.UpdateAsync(user);
        }

        public async Task<List<Recipes>> GetAllRecipes()
        {
            await Init();
            return await _connection.Table<Recipes>().ToListAsync();
        }

        public async Task CreateRecipe(Recipes recipe)
        {
            await Init();
            await _connection.InsertAsync(recipe);
        }

        // ✅ This method seeds the database with recipes
        public async Task SeedRecipes()
        {
            await Init();

            var existing = await GetAllRecipes();
            if (existing.Any()) return;

            var recipes = new List<Recipes>
            {
                new Recipes
                {
                    RecipeName = "Grilled Cheese Sandwich",
                    RecipeInstructions = "Butter bread, add cheese, grill until golden.",
                    Category = "Lunch",
                    Ingredients = new List<string> { "Bread", "Cheese", "Butter" }
                },
                new Recipes
                {
                    RecipeName = "Pasta Alfredo",
                    RecipeInstructions = "Boil pasta, add cream and cheese sauce.",
                    Category = "Dinner",
                    Ingredients = new List<string> { "Pasta", "Cream", "Parmesan", "Butter" }
                },
                new Recipes
                {
                    RecipeName = "Veggie Omelette",
                    RecipeInstructions = "Whisk eggs, add chopped veggies, cook in pan until set.",
                    Category = "Breakfast",
                    Ingredients = new List<string> { "Eggs", "Bell Pepper", "Onion", "Cheese" }
                },
                new Recipes
                {
                    RecipeName = "Avocado Toast",
                    RecipeInstructions = "Toast bread, mash avocado with salt and pepper, spread on toast.",
                    Category = "Breakfast",
                    Ingredients = new List<string> { "Bread", "Avocado", "Salt", "Pepper" }
                },
                new Recipes
                {
                    RecipeName = "Chicken Stir Fry",
                    RecipeInstructions = "Cook chicken, add veggies and sauce, stir fry until done.",
                    Category = "Dinner",
                    Ingredients = new List<string> { "Chicken", "Broccoli", "Soy Sauce", "Garlic" }
                }

            };

            foreach (var recipe in recipes)
            {
                await CreateRecipe(recipe);
            }
        }
        public async Task<List<Ingredient>> GetUserIngredientsAsync()
        {
            await Init();
            return await _connection.Table<Ingredient>()
                                    .Where(i => i.IsSelected == true)
                                    .ToListAsync();
        }
        public async Task<List<Recipes>> GetAllRecipesAsync()
        {
            await Init();
            return await _connection.Table<Recipes>().ToListAsync();
        }
        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            await Init();
            await _connection.InsertAsync(ingredient);
        }

        public async Task ClearAllIngredients()
        {
            await Init();
            await _connection.DeleteAllAsync<Ingredient>();
        }



    }
}
