using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // Needed for Preferences

namespace FinalProject_1;

public partial class movieDetails : ContentPage
{
    // 1. Define the base price per ticket
    double ticketPrice = 60.00;

    public movieDetails(Movie movie)
    {
        InitializeComponent();

        // 2. Fill the page with the clicked movie's data
        moviName.Text = movie.Name;
        moviClass.Text = movie.Genre;
        moviStory.Text = movie.Story;
        moviPoster.Source = movie.ImageUrl;

        // 3. Set the initial price text
        TotalPriceLabel.Text = $"{ticketPrice} SAR";

        // 4. Register Event Handlers
        BranchPicker.SelectedIndexChanged += OnSelectionChanged;
        MovieDatePicker.DateSelected += OnSelectionChanged;
        TicketsStepper.ValueChanged += OnTicketsChanged;

        foreach (var child in TimeOptions.Children)
        {
            if (child is RadioButton rb) rb.CheckedChanged += OnSelectionChanged;
        }
    }

    private void OnTicketsChanged(object sender, ValueChangedEventArgs e)
    {
        int count = (int)e.NewValue;
        TicketsLabel.Text = count.ToString();

        // Calculate Price
        double total = count * ticketPrice;
        TotalPriceLabel.Text = $"{total} SAR";

        OnSelectionChanged(sender, EventArgs.Empty);
    }

    private void OnSelectionChanged(object sender, EventArgs e)
    {
        bool branchSelected = BranchPicker.SelectedIndex != -1;
        bool timeSelected = TimeOptions.Children.OfType<RadioButton>().Any(rb => rb.IsChecked);

        NextButton.IsEnabled = branchSelected && timeSelected;
        NextButton.BackgroundColor = NextButton.IsEnabled ? Color.FromArgb("#ffb300") : Colors.Gray;
    }

    private async void OnNextClicked(object sender, EventArgs e)
    {
        // =========================================================
        // 🛑 FEATURE: CHECK IF USER IS LOGGED IN
        // =========================================================
        bool isLoggedIn = Preferences.Get("IsLoggedIn", false);

        if (!isLoggedIn)
        {
            // If NOT logged in, show alert and go to Login Page
            bool answer = await DisplayAlert("Login Required", "You must log in to continue.", "Login", "Cancel");

            if (answer)
            {
                await Navigation.PushAsync(new LogInPage());
            }

            // ⛔ STOP THE FUNCTION HERE. Do not let them pay.
            return;
        }
        // =========================================================

        // If we get here, the user IS logged in. Proceed to create ticket.
        RadioButton selectedTimeRadio = TimeOptions.Children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked);
        string timeText = selectedTimeRadio?.Content.ToString() ?? "Unknown";

        var newTicket = new ReservationTicket
        {
            MovieName = moviName.Text,
            Branch = BranchPicker.SelectedItem.ToString(),
            Date = MovieDatePicker.Date.ToString("dd/MM/yyyy"),
            Time = timeText,
            NumberOfTickets = (int)TicketsStepper.Value,
            TotalPrice = (int)TicketsStepper.Value * ticketPrice
        };

        // Go to Payment
        await Navigation.PushAsync(new PaymentPage(newTicket));
    }
}