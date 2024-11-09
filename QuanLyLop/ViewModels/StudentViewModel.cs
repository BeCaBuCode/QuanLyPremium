using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuanLyLop.Interfaces;
using QuanLyLop.Models;
using QuanLyLop.Services;

namespace QuanLyLop.ViewModels;

public partial class StudentViewModel : ObservableObject, IQueryAttributable
{
    private readonly IStudentRepo _studentRepo;
    [ObservableProperty] 
    private ObservableCollection<Student> students;
    private bool isInitialized=false;
    [ObservableProperty]
    Student selectedStudent=new ();

    private int classId=-1;
    public StudentViewModel(IStudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
        Students = new ObservableCollection<Student>();
    }
    private async void LoadStudentAsync()
    {
        var studentList = await _studentRepo.GetStudentsByClassIdAsync(classId);
        foreach (var student in studentList)
        {
            Students.Add(student);
        }
    }

    [RelayCommand]
    private void Selected(Student student)
    {
        SelectedStudent=student;
    }
    
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("student") && !isInitialized)
        {
            classId= Convert.ToInt32(query["student"]);
            isInitialized = true;
            LoadStudentAsync();
        }
        else if (query.ContainsKey("fullName"))
        {
            string fullName = Uri.UnescapeDataString(query["fullName"].ToString());
            string trytoConvert=Uri.UnescapeDataString(query["birthDate"].ToString());
            DateTime birthDate = Convert.ToDateTime(trytoConvert);
            int id = Convert.ToInt32(query["id"]);
            Student find = Students.FirstOrDefault(x => x.StudentId == id);
            if (find != null)
            {
                find.FullName = fullName;
                find.BirthDate = birthDate;
                _studentRepo.UpdateStudentAsync(find);
            }
            else
            {
                _studentRepo.AddStudentAsync(new Student
                    { FullName = fullName, BirthDate = birthDate, ClassId = classId });
                Students.Insert(Students.Count,new Student {FullName = fullName, BirthDate = birthDate, ClassId = classId, StudentId = Students.Count+1});
            }
        }
        else if (query.ContainsKey("delete"))
        {
            int id = Convert.ToInt32(query["delete"]);
            Student student = Students.FirstOrDefault(x => x.StudentId == id);
            if (student != null)
            {
                _studentRepo.DeleteStudentAsync(student);
                Students.Remove(student);
            }
        }
    }

    [RelayCommand]
    private async void New()
    {
        await Shell.Current.GoToAsync(nameof(Views.StudentDetail));
    }

    [RelayCommand]
    private async void Edit()
    {
        await Shell.Current.GoToAsync($"{nameof(Views.StudentDetail)}?name={SelectedStudent.FullName}&birth={SelectedStudent.BirthDate}&id={SelectedStudent.StudentId}");
    }
}