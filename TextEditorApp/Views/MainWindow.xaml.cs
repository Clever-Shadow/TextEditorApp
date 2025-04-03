using System.Windows;
using TextEditorApp.Data;
using TextEditorApp.Models;
using TextEditorApp.ViewModels;
using TextEditorApp.Views;

namespace TextEditorApp.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string _userRole;
    public MainWindow(string userRole)
    {
        InitializeComponent();
        _userRole = userRole;
        ConfigureUI();
        LoadItems();
    }
    
    private void ConfigureUI()
    {
        if (_userRole == "Operator")
        {
            DeleteButton.IsEnabled = false;
            EditButton.IsEnabled = false;
        }
    }
    private void LoadItems()
    {
        using (var context = new AppDbContext())
        {
            ItemsListBox.ItemsSource = context.TextItems.ToList();
        }
    }
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        using (var context = new AppDbContext())
        {
            var newItem = new TextItem { Content = "Новый элемент" };
            context.TextItems.Add(newItem);
            context.SaveChanges();
        }
        LoadItems();
    }
    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (ItemsListBox.SelectedItem is TextItem selectedItem)
        {
            using (var context = new AppDbContext())
            {
                var item = context.TextItems.FirstOrDefault(t => t.Id == selectedItem.Id);
                if (item != null)
                {
                    item.Content = "Измененный текст";
                    context.SaveChanges();
                }
            }
            LoadItems();
        }
        else
        {
            MessageBox.Show("Выберите элемент для редактирования.");
        }
    }
    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (ItemsListBox.SelectedItem is TextItem selectedItem)
        {
            using (var context = new AppDbContext())
            {
                var item = context.TextItems.FirstOrDefault(t => t.Id == selectedItem.Id);
                if (item != null)
                {
                    context.TextItems.Remove(item);
                    context.SaveChanges();
                }
            }
            LoadItems();
        }
        else
        {
            MessageBox.Show("Выберите элемент для удаления.");
        }
    }
    private void LogOut_Click(object sender, RoutedEventArgs e)
    {
        LoginWindow loginWindow = new();
        loginWindow.Show();
        Close();
    }
}