using CookingPal.Service;
using CookingPal.Model;

namespace CookingPal.Pages;

public partial class RegisterPage : ContentPage
{
    private readonly LocalDb _localDb;
    public RegisterPage(LocalDb localDb)
    {
        InitializeComponent();
        _localDb = new LocalDb();
       
       
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        var name = NameEntry.Text;
        var email = EmailEntry.Text;
        var password = PasswordEnter.Text;
        var confirm = ConfirmPasswordEntry.Text;

        if (_localDb == null)
        {
            await DisplayAlert("Debug", "_localDb is null!", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "All fields are required.", "OK");
            return;
        }

        // ? Enforce strong password
        if (password.Length < 8 || !password.Any(char.IsDigit) || !password.Any(char.IsUpper))
        {
            await DisplayAlert("Error", "Password must be at least 8 characters long and include at least one digit and one uppercase letter.", "OK");
            return;
        }

        if (password != confirm)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        // ? Create user and hash password
        var user = new User
        {
            Name = name,
            Email = email
        };
        user.SetPassword(password); // Hashing here

        await _localDb.Create(user);

        await DisplayAlert("Success", "Account created successfully!", "OK");
        await Navigation.PopAsync(); // Back to login
    }

    private async void OnLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Back to LoginPage
    }
}
