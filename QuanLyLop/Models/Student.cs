using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;

namespace QuanLyLop.Models;

public partial class Student:ObservableObject
{
    [Key] 
    [ObservableProperty] 
    private int studentId;

    [ObservableProperty]
    public string fullName="";

    [ObservableProperty] 
    public DateTime birthDate;

    [ForeignKey("Class")]
    public int ClassId { get; set; }
}