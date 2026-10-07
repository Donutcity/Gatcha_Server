using Microsoft.EntityFrameworkCore;
public enum ownership_status
{
    owned,
    equipped, 
    unowned
}
public enum Type
{
    background, 
    character,
    timer
}
public class Item
{
    public int Id { get; set; }
    public Type Type { get; set; }
    public ownership_status Ownership_status { get; set; }
    public int value { get; set; } 
}
public class User
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Display_name { get; set; } = string.Empty;

    public int Coins { get; set; } = 0;
    public int selected_background { get; set; } = 0;
    public int selected_character { get; set; } = 0;
    public int selected_timer { get; set; } = 0;

}
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Users.db");
    }
}

