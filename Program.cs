using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "defult");

app.MapGet("/buy", (int user_id, AppDbContext db) =>
{
     var currect_user = db.Users.FirstOrDefault(u=> u.Id == user_id);
    if(currect_user!.Coins >= 20)
    {
        currect_user.Coins =-20;    
    }
});
app.MapGet("/signup", (string username, string password, string display_name, AppDbContext db) =>
{
    var existingUser = db.Users.FirstOrDefault(u => u.Username == username);

    if (existingUser != null)
        return Results.BadRequest("Username already exists");

    var user = new User
    {
        Username = username,
        Password = password,
        Display_name = display_name,
         Coins = 100,
         selected_background =0,
         selected_character = 0,
         selected_timer = 0
    };

    db.Users.Add(user);
    db.SaveChanges();

    return Results.Ok(user);
});

app.MapGet("/login", (string username, string password, AppDbContext db) =>
{
    var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

    if (user != null)
        return Results.Ok(user);

    return Results.BadRequest("Invalid username or password");
});

app.Run();





