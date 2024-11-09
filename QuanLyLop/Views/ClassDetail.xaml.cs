using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLop.ViewModels;

namespace QuanLyLop.Views;

public partial class ClassDetail : ContentPage
{
    public ClassDetail(ClassDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}