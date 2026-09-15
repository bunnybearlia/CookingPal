using CookingPal.Model;
using CookingPal.Service;

namespace CookingPal.Pages;

public partial class LoginPage : ContentPage
{
    private readonly LocalDb _localDb;

    public LoginPage()
    {
        InitializeComponent();
        _localDb = new LocalDb(); // You could inject this too
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please fill in both fields.", "OK");
            return;
        }

        var user = await _localDb.GetUserByCredentials(email, password);

        if (user != null)
        {
            await DisplayAlert("Success", $"Welcome back, {user.Name}!", "OK");
            await Navigation.PushAsync(new HomePage(_localDb, user));

        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid email or password.", "OK");
        }
    }



    private async void OnSignUpTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage(_localDb));

    }
}
