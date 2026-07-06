namespace FinalProject_1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // CHANGE THIS LINE:
        // Instead of new NavigationPage(new MainPage()), we use AppShell
        MainPage = new AppShell();
    }
}
    public class ReservationTicket
    {
    public string MovieName { get; set; }
    public string Branch { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public int NumberOfTickets { get; set; }
    public double TotalPrice { get; set; }
}