namespace TextEditorApp.ViewModels;
using CommunityToolkit.Mvvm.Input;
using Data;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;

public partial class LoginViewModel : ObservableObject
{
    private readonly AppDbContext _context = new();

    [ObservableProperty]
    private string username = string.Empty;

    public bool TryLogin(string password)
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(password))
            return false;

        var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == password);
        return user != null;
    }
    public string GetUserRole(string password)
    {
        using (var context = new AppDbContext())
        {
            var user = context.Users.FirstOrDefault(u => u.Password == password);
            return user?.Role;
        }
    }
}

