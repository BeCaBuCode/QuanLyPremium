using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLop.ViewModels;

namespace QuanLyLop.Views;

public partial class StudentDetail : ContentPage
{
    public StudentDetail(StudentDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}