using CookingPal.Model;
using CookingPal.Service;
using System.Collections.ObjectModel;
using System.Linq;

namespace CookingPal.Pages
{
    public partial class MyIngredientsPage : ContentPage
    {
        private readonly LocalDb _localDb;
        private readonly User _loggedInUser;

        public ObservableCollection<Ingredient> AllIngredients { get; set; }

        public MyIngredientsPage(LocalDb localDb, User loggedInUser)
        {
            InitializeComponent();
            _localDb = localDb;
            _loggedInUser = loggedInUser;

            AllIngredients = new ObservableCollection<Ingredient>
            {
                new Ingredient { ItemName = "Pasta" },
                new Ingredient { ItemName = "Tomato Sauce" },
                new Ingredient { ItemName = "Cheese" },
                new Ingredient { ItemName = "Chicken" },
                new Ingredient { ItemName = "Rice" },
                new Ingredient { ItemName = "Eggs" },
                new Ingredient { ItemName = "Milk" },
                new Ingredient { ItemName = "Bread" },
                 new Ingredient { ItemName = "Butter" },
                  new Ingredient { ItemName = "Avocado" },
                new Ingredient { ItemName = "Salt" },
                new Ingredient { ItemName = "Pepper" },
                new Ingredient { ItemName = "Onion" },
                new Ingredient { ItemName = "Garlic" },
                new Ingredient { ItemName = "Cream" },
                new Ingredient { ItemName = "Parmesan" },
                new Ingredient { ItemName = "Bell Pepper" },
                new Ingredient { ItemName = "Broccoli" },
                new Ingredient { ItemName = "Soy Sauce" },
                new Ingredient { ItemName = "Oil" }

            };
            var savedList = _loggedInUser.UserIngredients?.Split(',') ?? Array.Empty<string>();

            foreach (var item in AllIngredients)
            {
                if (savedList.Contains(item.ItemName))
                    item.IsSelected = true;
            }

            BindingContext = this;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var selectedIngredients = AllIngredients.Where(i => i.IsSelected).ToList();

            // Clear existing ingredients in the Ingredient table
            await _localDb.ClearAllIngredients();

            // Insert selected ingredients
            foreach (var ingredient in selectedIngredients)
            {
                await _localDb.CreateIngredientAsync(ingredient);
            }

            await DisplayAlert("Saved", "Ingredients saved!", "OK");
            await Navigation.PopAsync();
        }


    }
}
