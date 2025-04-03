using System.Windows;
using TextEditorApp.Data;
using TextEditorApp.Models;
using TextEditorApp.Views;

namespace TextEditorApp;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.Add(new User { Username = "aa", Password = "aa", Role = "Admin" });
                context.Users.Add(new User { Username = "op", Password = "op", Role = "Operator" });
                context.SaveChanges();
            }
        }
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.Show();
    }
}