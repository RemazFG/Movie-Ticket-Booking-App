using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // Needed for Preferences

namespace FinalProject_1;

public partial class LogInPage : ContentPage
{
    public LogInPage()
    {
        InitializeComponent();
    }

    // Updates the button state when text changes [cite: 294]
    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Using "EmailEntry" and "PasswordEntry" because that is what is in your XAML [cite: 263, 268]
        LogInButton.IsEnabled = !string.IsNullOrWhiteSpace(EmailEntry.Text) &&
                                !string.IsNullOrWhiteSpace(PasswordEntry.Text);
    }

    async void OnLogInClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EmailEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter email and password", "OK");
            return;
        }

        // --- SIMULATED LOGIN ---
        // (You can uncomment your DatabaseService code here if you want real checking)
        // var user = await DatabaseService.LoginUser(EmailEntry.Text, PasswordEntry.Text);

        bool loginSuccess = true; // For testing, we assume login is always true

        if (loginSuccess)
        {
            // 1. Save that the user is logged in
            Preferences.Set("IsLoggedIn", true);

            await DisplayAlert("Success", "Welcome back!", "OK");

            // 2. Go back to the previous page (Movie Details) instead of resetting MainPage
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Invalid email or password.", "OK");
        }
    }

    async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }
}