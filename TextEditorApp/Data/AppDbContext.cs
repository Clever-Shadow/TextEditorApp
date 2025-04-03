using TextEditorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TextEditorApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<TextItem> TextItems { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=app.db");
    }
}