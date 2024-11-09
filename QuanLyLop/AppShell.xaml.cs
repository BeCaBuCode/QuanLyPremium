namespace QuanLyLop;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.ClassPage),typeof(Views.ClassPage));
		Routing.RegisterRoute(nameof(Views.ClassDetail),typeof(Views.ClassDetail));
		Routing.RegisterRoute(nameof(Views.StudentPage),typeof(Views.StudentPage));
		Routing.RegisterRoute(nameof(Views.StudentDetail),typeof(Views.StudentDetail));
	}
}
