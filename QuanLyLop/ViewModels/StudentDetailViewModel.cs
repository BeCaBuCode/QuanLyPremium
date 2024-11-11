using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace QuanLyLop.ViewModels;

public partial class StudentDetailViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty] private string _fullName = "";
    [ObservableProperty] private DateTime _birthDate;

    private int _id = -1;

    [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrWhiteSpace(FullName))
        {
            return;
        }
        await Shell.Current.GoToAsync($"..?fullName={FullName}&birthDate={BirthDate}&id={_id}");
    }

    [RelayCommand]
    private async Task Delete()
    {
        await Shell.Current.GoToAsync($"..?delete={_id}");
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("name", out var name)) return;
        FullName = Uri.UnescapeDataString(name.ToString() ?? "");
        var inputBirthday = Uri.UnescapeDataString(query["birth"].ToString() ?? "01/01/0001");
        var isValid = DateTime.TryParse(inputBirthday, out var date);
        BirthDate = isValid ? date : DateTime.Today;
        _id = Convert.ToInt32(query["id"]);
    }
}