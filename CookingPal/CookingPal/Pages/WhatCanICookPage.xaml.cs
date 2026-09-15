using System.Collections.ObjectModel;
using CookingPal.Model;
using CookingPal.Service;

namespace CookingPal.Pages;

public partial class WhatCanICookPage : ContentPage
{
    // Observable collections bound to the UI lists
    private ObservableCollection<Recipes> canCook = new();
    

    public WhatCanICookPage()
    {
        InitializeComponent();

        // Set the ItemSources of CollectionViews
        CanCookList.ItemsSource = canCook;
        

        _ = LoadSuggestions();  // Load all recipes initially
    }

    private async Task LoadSuggestions(string filterType = "All")
    {
        // Step 1: Get all user ingredients from the DB
        var userIngredients = await App.Database.GetUserIngredientsAsync();
        var userIngredientNames = userIngredients.Select(i => i.ItemName.ToLower()).ToList();

        // Step 2: Get all recipes from DB
        var recipeEntities = await App.Database.GetAllRecipesAsync();

        // Step 3: Filter by meal type if needed
        if (filterType != "All")
            recipeEntities = recipeEntities.Where(r => r.Category == filterType).ToList();

        // Step 4: Clear previous results
        canCook.Clear();
      

        // Step 5: Sort recipes into canCook or almost
        foreach (var dbRecipe in recipeEntities)
        {
            var missing = dbRecipe.Ingredients
                                  .Select(i => i.ToLower())
                                  .Except(userIngredientNames)
                                  .ToList();

            if (missing.Count == 0)
            {
                canCook.Add(dbRecipe);
            }
           
        }
    }

    private void OnMealTypeSelected(object sender, EventArgs e)
    {
        var selected = MealTypePicker.SelectedItem?.ToString() ?? "All";
        _ = LoadSuggestions(selected);
    }
    private async void OnRecipeSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Recipes selectedRecipe)
        {
            await Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
            CanCookList.SelectedItem = null; // Deselect the item to remove highlight
        }
    }



}
