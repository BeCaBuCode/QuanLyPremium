using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using QuanLyLop.Data;
using QuanLyLop.Services;

namespace QuanLyLop.ViewModels;

public partial class MainViewModel:ObservableObject
{
    private readonly DatabaseService _databaseService;
    [ObservableProperty] private static string link = "";

    public MainViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
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
            _databaseService.Initialize(Link);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
           _databaseService.Initialize(Path.Combine(FileSystem.AppDataDirectory, "mydb.db"));
        }
        await Shell.Current.GoToAsync(nameof(Views.ClassPage));
    }
}