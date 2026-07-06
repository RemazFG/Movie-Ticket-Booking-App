using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace FinalProject_1;

public static class DatabaseService
{
    private static SQLiteAsyncConnection _db;

    // 1. Initialize the connection
    static async Task Init()
    {
        if (_db != null)
            return; // Already initialized

        // Get a valid path on the phone to save the file
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MagicCinema.db3");

        _db = new SQLiteAsyncConnection(databasePath);

        // Create the User table if it doesn't exist
        await _db.CreateTableAsync<User>();
    }

    // 2. Add a new User (Sign Up)
    public static async Task AddUser(string name, string email, string password)
    {
        await Init();
        var newUser = new User
        {
            Name = name,
            Email = email,
            Password = password
        };

        await _db.InsertAsync(newUser);
    }

    // 3. Find a User (Log In)
    public static async Task<User> LoginUser(string email, string password)
    {
        await Init();
        // Look for a user that matches BOTH email and password
        var user = await _db.Table<User>()
                            .Where(u => u.Email == email && u.Password == password)
                            .FirstOrDefaultAsync();
        return user;
    }
}