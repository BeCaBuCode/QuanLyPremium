using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuanLyLop.Data;
using QuanLyLop.Services;

namespace QuanLyLop.ViewModels;

public partial class MainViewModel(DatabaseService databaseService) : ObservableObject
{
    [ObservableProperty] 
    private string _link = "";
    
    [RelayCommand]
    private async Task NavigateCommand()
    {
        if (string.IsNullOrEmpty(Link))
        {
            if (Application.Current?.MainPage!=null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a link", "OK");
            }
            return;
        }

        try
        {
            databaseService.Initialize(Link);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            databaseService.Initialize(Path.Combine(FileSystem.AppDataDirectory, "mydb.db"));
        }
        await Shell.Current.GoToAsync(nameof(Views.ClassPage));
    }
}