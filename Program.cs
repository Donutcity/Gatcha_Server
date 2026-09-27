using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "defult");
app.MapGet("/signup", (string username, string password, string display_name, AppDbContext db) =>
{
    var existingUser = db.Users.FirstOrDefault(u => u.Username == username);

    if (existingUser != null)
        return "username taken";

    var user = new User
    {
        Username = username,
        Password = password,
        Display_name = display_name
    };

    db.Users.Add(user);
    db.SaveChanges();

    return "user created";
});
app.MapGet("/login", (string username, string password, AppDbContext db) =>
{
    var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

    if (user != null)
        return $"Welcome {user.Display_name}";

    return "Invalid username or password";
});

app.Run();





