using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuanLyLop.Interfaces;
using QuanLyLop.Models;

namespace QuanLyLop.ViewModels;

public partial class ClassViewModel:ObservableObject,IQueryAttributable
{
    private readonly IClassRepo _classRepository;
    [ObservableProperty]
    ObservableCollection<Class> classes;
    [ObservableProperty]
    Class selectedClass=new ();
    public ClassViewModel(IClassRepo iClassRepo)
    {
        _classRepository = iClassRepo;
        classes = new ObservableCollection<Class>();
        LoadClassesAsync();
    }

    [RelayCommand]
    private async Task New()
    {
        await Shell.Current.GoToAsync(nameof(Views.ClassDetail));
    }
    private async void LoadClassesAsync()
    {
        var classes = await _classRepository.GetClassesAsync();
        foreach (var classItem in classes)
        {
            Classes.Add(classItem);
        }
    }
    [RelayCommand]
    private void Selected(Class selected)
    {
        SelectedClass = selected;
    }
    [RelayCommand]
    private async Task Edit()
    {
        await Shell.Current.GoToAsync($"{nameof(Views.ClassDetail)}?load={SelectedClass.ClassName}&id={SelectedClass.ClassId}");
    }

    [RelayCommand]
    private async Task GoToClass()
    {
        await Shell.Current.GoToAsync($"{nameof(Views.StudentPage)}?student={SelectedClass.ClassId}");
    }
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("save"))
        {
            var classReceiveEncoded = query["save"].ToString();
            string classReceive = Uri.UnescapeDataString(classReceiveEncoded??"");
            var classId = Convert.ToInt32(query["id"]);
            Class? find = Classes.FirstOrDefault(x => x.ClassId == classId);
            if ( find!= null)
            {
                find.ClassName = classReceive;
                _classRepository.UpdateClassAsync(find);
            }
            else
            {
                _classRepository.AddClassAsync(new Class {ClassName = classReceive});
                Classes.Clear();
                LoadClassesAsync();
            }
        }
        else if (query.ContainsKey("delete"))
        {
            var classReceive = query["delete"].ToString();
            var classId = Convert.ToInt32(query["id"]);
            Class? find = Classes.FirstOrDefault(Class => Class.ClassId == classId);
            if (find != null)
            {
                _classRepository.DeleteClassAsync(find);
                Classes.Remove(find);
            }
        }
    }
}