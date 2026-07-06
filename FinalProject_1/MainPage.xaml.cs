using Microsoft.Maui.Controls;

namespace FinalProject_1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // 1. HERO MOVIE (Avatar) - Clicked via "Book Now" button
    private async void OnBookNowClicked(object sender, EventArgs e)
    {
        var avatarMovie = new Movie
        {
            Name = "Avatar: The Way of Water",
            Genre = "Sci-Fi | Adventure",
            Story = "Jake Sully lives with his newfound family formed on the extrasolar moon Pandora. Once a familiar threat returns to finish what was previously started, Jake must work with Neytiri and the army of the Na'vi race to protect their home.",
            ImageUrl = "https://image.tmdb.org/t/p/original/t6HIqrRAclMCA60NsSmeqe9RmNV.jpg" // High Res Avatar Image
        };

        await Navigation.PushAsync(new movieDetails(avatarMovie));
    }

    // 2. Oppenheimer Clicked
    private async void OnOppenheimerClicked(object sender, EventArgs e)
    {
        var movie = new Movie
        {
            Name = "Oppenheimer",
            Genre = "Drama | History",
            Story = "The story of American scientist J. Robert Oppenheimer and his role in the development of the atomic bomb.",
            ImageUrl = "https://image.tmdb.org/t/p/w500/r21n2yV97xtrXy5q8PZREh9v1Gv.jpg"
        };
        await Navigation.PushAsync(new movieDetails(movie));
    }

    // 3. Infinity War Clicked
    private async void OnInfinityWarClicked(object sender, EventArgs e)
    {
        var movie = new Movie
        {
            Name = "Avengers: Infinity War",
            Genre = "Action | Sci-Fi",
            Story = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
            ImageUrl = "https://image.tmdb.org/t/p/w500/7WsyChQLEftFiDOVTGkv3hFpyyt.jpg"
        };
        await Navigation.PushAsync(new movieDetails(movie));
    }

    // 4. Batman Clicked
    private async void OnBatmanClicked(object sender, EventArgs e)
    {
        var movie = new Movie
        {
            Name = "The Batman",
            Genre = "Action | Crime",
            Story = "When a sadistic serial killer begins murdering key political figures in Gotham, Batman is forced to investigate the city's hidden corruption and question his family's involvement.",
            ImageUrl = "https://image.tmdb.org/t/p/w500/ngl2FKBlU4fhbdsrtdom9LVLBXw.jpg"
        };
        await Navigation.PushAsync(new movieDetails(movie));
    }

    // 5. Joker Clicked
    private async void OnJokerClicked(object sender, EventArgs e)
    {
        var movie = new Movie
        {
            Name = "Joker",
            Genre = "Crime | Drama",
            Story = "During the 1980s, a failed stand-up comedian is driven insane and turns to a life of crime and chaos in Gotham City while becoming an infamous psychopathic crime figure.",
            ImageUrl = "https://image.tmdb.org/t/p/w500/udDclJoHjfjb8Ekgsd4FDteOkCU.jpg"
        };
        await Navigation.PushAsync(new movieDetails(movie));
    }

    // 6. Spider-Man Clicked
    private async void OnSpiderManClicked(object sender, EventArgs e)
    {
        var movie = new Movie
        {
            Name = "Spider-Man: Across the Spider-Verse",
            Genre = "Animation | Action",
            Story = "After reuniting with Gwen Stacy, Brooklyn's full-time, friendly neighborhood Spider-Man is catapulted across the Multiverse, where he encounters the Spider Society.",
            ImageUrl = "https://image.tmdb.org/t/p/w500/8Vt6mWEReuy4Of61Lnj5Xj704m8.jpg"
        };
        await Navigation.PushAsync(new movieDetails(movie));
    }

    // 7. Dune Clicked
    private async void OnDuneClicked(object sender, EventArgs e)
    {
        var movie = new Movie
        {
            Name = "Dune: Part Two",
            Genre = "Sci-Fi | Adventure",
            Story = "Paul Atreides unites with Chani and the Fremen while on a warpath of revenge against the conspirators who destroyed his family.",
            ImageUrl = "https://image.tmdb.org/t/p/w500/1pdfLvkbY9ohJlCjQH2CZjjYVvJ.jpg"
        };
        await Navigation.PushAsync(new movieDetails(movie));
    }

    // 8. Inside Out Clicked
    private async void OnInsideOutClicked(object sender, EventArgs e)
    {
        var movie = new Movie
        {
            Name = "Inside Out 2",
            Genre = "Animation | Family",
            Story = "Teenager Riley's mind headquarters is undergoing a sudden demolition to make room for something entirely unexpected: new Emotions!",
            ImageUrl = "https://image.tmdb.org/t/p/w500/vpnVM9B6NMmQpWeZvzLvDESb2QY.jpg"
        };
        await Navigation.PushAsync(new movieDetails(movie));
    }
}