namespace FinalProject_1;

public partial class BookingSuccessPage : ContentPage
{
    // Default constructor (required for generic navigation, though we won't use it directly)
    public BookingSuccessPage()
    {
        InitializeComponent();
    }

    // Constructor that accepts the Ticket
    public BookingSuccessPage(ReservationTicket ticket)
    {
        InitializeComponent();

        // Display the Data
        MovieNameLabel.Text = ticket.MovieName;
        BranchLabel.Text = ticket.Branch;
        DateLabel.Text = ticket.Date;
        TimeLabel.Text = ticket.Time;
        TicketsLabel.Text = $"{ticket.NumberOfTickets} Tickets";
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}