using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace QuanLyLop.ViewModels;

public partial class StudentDetailViewModel:ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    private string fullName="";
    [ObservableProperty]
    private DateTime birthDate;

    private int id = -1;
    [RelayCommand]
    private async Task Save()
    {
        if (!string.IsNullOrWhiteSpace(FullName))
        {
            await Shell.Current.GoToAsync($"..?fullName={FullName}&birthDate={BirthDate}&id={id}");
        }
    }
    [RelayCommand]
    private async Task Delete()
    {
        await Shell.Current.GoToAsync($"..?delete={id}");
    }
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("name"))
        {
            FullName = Uri.UnescapeDataString(query["name"].ToString()??"");
            string trytoConvert=Uri.UnescapeDataString(query["birth"].ToString()??"01/01/0001");
            BirthDate = DateTime.Parse(trytoConvert);
            id = Convert.ToInt32(query["id"]);
        }
    }
}