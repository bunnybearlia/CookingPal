namespace CookingPal.Pages;

public partial class FavoritesPage : ContentPage
{
	public FavoritesPage()
	{
		InitializeComponent();
        LoadFavorites();
    }
    private void LoadFavorites()
    {
        var favorites = new List<Recipe>
        {
            new Recipe { Name = "Mac and Cheese", Description = "Creamy, cheesy comfort food." },
            new Recipe { Name = "Chicken Alfredo", Description = "Rich pasta with chicken and white sauce." },
            new Recipe { Name = "Avocado Toast", Description = "Quick and healthy breakfast option." }
        };

        FavoritesList.ItemsSource = favorites;
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Goes back to HomePage
    }

    public class Recipe
    {
        public string Name { get; set; } = " ";
        public string Description { get; set; } = "";

    }
}