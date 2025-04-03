namespace TextEditorApp.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Models;
public partial class TextViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<TextItem> items = new();

    [RelayCommand]
    private void AddItem()
    {
        Items.Add(new TextItem { Content = "Новый элемент" });
    }

    [RelayCommand]
    private void DeleteItem(TextItem? item)
    {
        if (item != null)
            Items.Remove(item);
    }
}
