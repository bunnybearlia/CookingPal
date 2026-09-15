using CookingPal.Model;

namespace CookingPal.Pages;

public partial class RecipeDetailPage : ContentPage
{
    private Recipes _recipe;

    public RecipeDetailPage(Recipes recipe)
    {
        InitializeComponent();
        _recipe = recipe;

        // Set UI values
        RecipeNameLabel.Text = _recipe.RecipeName;
        IngredientsLabel.Text = string.Join(", ", _recipe.Ingredients);
        InstructionsLabel.Text = _recipe.RecipeInstructions;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
