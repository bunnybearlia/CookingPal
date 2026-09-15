using CookingPal.Model;
using CookingPal.Service;

namespace CookingPal.Pages
{
    public partial class HomePage : ContentPage
    {
        private readonly LocalDb _localDb;
        private readonly User _loggedInUser;

        public HomePage(LocalDb localDb, User loggedInUser)
        {
            InitializeComponent();
            _localDb = localDb;
            _loggedInUser = loggedInUser;
        }

        private async void OnWhatCanICookClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Navigation", "This will take you to 'What Can I Cook?'", "OK");
            await Navigation.PushAsync(new WhatCanICookPage());
        }

        private async void OnAllRecipesClicked(object sender, EventArgs e)
        {
            await _localDb.SeedRecipes(); // Optional: seed recipes if needed
            await Navigation.PushAsync(new AllRecipesPage(_localDb));
        }


        private async void OnMyIngredientsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Navigation", "This will take you to 'My Ingredients'", "OK");
            await Navigation.PushAsync(new MyIngredientsPage(_localDb, _loggedInUser));
        }

        private async void OnFavoritesClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Navigation", "This will take you to 'Favorites'", "OK");
            await Navigation.PushAsync(new FavoritesPage());
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");
            if (confirm)
            {
                await Navigation.PushAsync(new LoginPage()); // pass db for reuse
            }
        }
    }
}
