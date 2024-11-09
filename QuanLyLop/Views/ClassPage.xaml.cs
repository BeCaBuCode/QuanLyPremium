using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLop.ViewModels;

namespace QuanLyLop.Views;

public partial class ClassPage : ContentPage
{
    public ClassPage(ClassViewModel viewModel)
    {
        InitializeComponent();
        BindingContext=viewModel;
    }
}