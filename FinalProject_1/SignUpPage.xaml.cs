using Microsoft.Maui.Controls;

namespace FinalProject_1;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    async void OnCreateAccountClicked(object sender, EventArgs e)
    {
        // 1. Check for empty fields (Keep your existing validation code here)
        if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
            string.IsNullOrWhiteSpace(EmailSignUpEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordSignUpEntry.Text))
        {
            await DisplayAlert("Error", "Please fill all fields", "OK");
            return;
        }

        // 2. Try to save to Database
        try
        {
            await DatabaseService.AddUser(NameEntry.Text, EmailSignUpEntry.Text, PasswordSignUpEntry.Text);

            await DisplayAlert("Success", "Account created! You can now log in.", "OK");
            await Navigation.PopAsync(); // Go back to Login
        }
        catch (Exception)
        {
            // This runs if the email is not unique (because of [Unique] attribute)
            await DisplayAlert("Error", "This email is already registered.", "OK");
        }
    }
}