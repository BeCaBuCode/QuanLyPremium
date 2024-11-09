using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuanLyLop.Models;

namespace QuanLyLop.ViewModels;

public partial class ClassDetailViewModel : ObservableObject,IQueryAttributable
{
    [ObservableProperty] private string name = "";
    private int id=-1;
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("load"))
        {
            Name= Uri.UnescapeDataString(query["load"].ToString());
            id =Convert.ToInt32(query["id"]);
        }
    }

    [RelayCommand]
    private async void Save()
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            await Shell.Current.GoToAsync($"..?save={Name}&id={id}");
        }
    }
    [RelayCommand]
    private async void Delete()
    {
        await Shell.Current.GoToAsync($"..?delete={Name}&id={id}");
    }
}