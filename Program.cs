using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "defult");

app.MapGet("/buy", (int user_id, int item_id, AppDbContext db) =>
{
     var currect_user = db.Users.FirstOrDefault(u=> u.Id == user_id);
     var current_item = db.Items.FirstOrDefault(u=> u.Id == item_id);
     if(currect_user == null || current_item == null) return Results.Ok("either item or user doesn't exist");
    if(currect_user.Coins < current_item.value)
    {
         return Results.Ok("not enough money");
    }
    if(db.user_Owneds.FirstOrDefault(u=> u.user_id == currect_user.Id && u.item_id == current_item.Id )!= null)
    {
        
        if(current_item.Type == Type.timer)
        {
            currect_user.selected_timer = current_item.Id;  
        } 
        if(current_item.Type == Type.background)
        {
            currect_user.selected_background = current_item.Id;  
        } 
        if(current_item.Type == Type.character)
        {
            currect_user.selected_character = current_item.Id;  
        } 
        db.SaveChanges();
        return Results.Ok("equiped");
    }
    currect_user.Coins =- current_item.value; 

    user_owned us = new user_owned()
    {
      user_id = currect_user.Id,
      item_id = current_item.Id,  
    };

    db.user_Owneds.Add(us);
    db.SaveChanges();
     return Results.Ok("complete");
});
app.MapGet("/user_banking_info" ,()=>
{
    return Results.Ok("bro thought there was actually banking info here lamfo https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBnPXfkBUXXru9ypY6Ru8xcsqiHxjddcZUws4frHaGDByA_IyUq4x77FW_&s=10");
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





