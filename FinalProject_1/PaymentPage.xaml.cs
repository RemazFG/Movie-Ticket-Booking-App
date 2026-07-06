using Microsoft.Maui.Controls;

namespace FinalProject_1;

public partial class PaymentPage : ContentPage
{
    private ReservationTicket _ticket;
    private string selectedPayment;
    private bool isDiscountApplied = false;

    // Constructor that accepts the Ticket [cite: 520, 592]
    public PaymentPage(ReservationTicket ticket)
    {
        InitializeComponent();
        _ticket = ticket;

        // Update the price label to show the correct amount initially
        UpdatePriceDisplay();
    }

    private void UpdatePriceDisplay()
    {
        if (_ticket != null)
        {
           // Update the label defined in your XAML (moviePriceLabel) [cite: 541]
            moviePriceLabel.Text = $"Total Price: {_ticket.TotalPrice:F2} SAR";
        }
    }

    // --- COUPON LOGIC (CM20) ---
    private void ApplyCouponClicked(object sender, EventArgs e)
    {
        // Get the text from the Entry named "CouponEntry" in your XAML [cite: 535]
        string code = CouponEntry.Text?.Trim().ToUpper();

        if (string.IsNullOrEmpty(code))
        {
            DisplayAlert("Error", "Please enter a coupon code.", "OK");
            return;
        }

        if (isDiscountApplied)
        {
            DisplayAlert("Info", "Discount already applied.", "OK");
            return;
        }

        // Check for the specific code "CM20"
        if (code == "CM20")
        {
            // Apply 20% Discount
            double discountAmount = _ticket.TotalPrice * 0.20;
            _ticket.TotalPrice = _ticket.TotalPrice - discountAmount;

            isDiscountApplied = true;
            UpdatePriceDisplay();

            DisplayAlert("Success", "Coupon CM20 applied! You saved 20%.", "OK");
        }
        else
        {
            DisplayAlert("Error", "Invalid coupon code.", "OK");
        }
    }

    // This handles the Radio Button selection [cite: 548, 556, 564]
    private void PaymentOptionChanged(object sender, CheckedChangedEventArgs e)
    {
        var radio = sender as RadioButton;
        if (radio != null && radio.IsChecked)
        {
            selectedPayment = radio.Content.ToString();

            // Enable the Pay button once a method is chosen [cite: 572]
            payButton.IsEnabled = true;
            payButton.BackgroundColor = Color.FromArgb("#ffb300"); // Gold color
        }
    }

    private async void PayClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(selectedPayment)) return;

        await DisplayAlert("Processing", $"Processing payment via {selectedPayment}...", "OK");

        // Pass the ticket to the Success Page
        await Navigation.PushAsync(new BookingSuccessPage(_ticket));
    }
}