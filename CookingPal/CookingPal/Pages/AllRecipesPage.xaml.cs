using CookingPal.Model;
using CookingPal.Service;

namespace CookingPal.Pages;

public partial class AllRecipesPage : ContentPage
{
    private readonly LocalDb _localDb;

    public AllRecipesPage(LocalDb localDb)
    {
        InitializeComponent();
        _localDb = localDb;
        LoadRecipes();
    }

    private async void LoadRecipes()
    {
        var recipes = await _localDb.GetAllRecipes();
        RecipesCollectionView.ItemsSource = recipes;
    }

    private async void OnRecipeSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Recipes selectedRecipe)
        {
            await Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
            RecipesCollectionView.SelectedItem = null; // Deselect
        }
    }
}
