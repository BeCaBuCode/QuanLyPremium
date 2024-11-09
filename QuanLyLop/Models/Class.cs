using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace QuanLyLop.Models;

public partial class Class : ObservableObject
{
    [Key] 
    [ObservableProperty] 
    private int classId;

    [ObservableProperty] 
    private string className = "";
}