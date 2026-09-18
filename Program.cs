var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "defult");
app.MapGet("/signup", (string username, string password, string displayname) =>
{
    //put the thingy in the tata    
});

app.Run();
