using QuanLyLop.ViewModels;

namespace QuanLyLop.Views;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

