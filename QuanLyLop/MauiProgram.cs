using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuanLyLop.Data;
using QuanLyLop.Interfaces;
using QuanLyLop.Services;
using QuanLyLop.ViewModels;
using QuanLyLop.Views;

namespace QuanLyLop;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();
		
		builder.Services.AddSingleton<DatabaseService>();
		
		builder.Services.AddTransient<ClassPage>();
		builder.Services.AddTransient<ClassViewModel>();
		
		builder.Services.AddTransient<ClassDetail>();
		builder.Services.AddTransient<ClassDetailViewModel>();
		
		builder.Services.AddTransient<StudentPage>();
		builder.Services.AddTransient<StudentViewModel>();
		
		builder.Services.AddTransient<StudentDetail>();
		builder.Services.AddTransient<StudentDetailViewModel>();
		
		builder.Services.AddScoped<IClassRepo, ClassRepo>();
		builder.Services.AddScoped<IStudentRepo, StudentRepo>();
		return builder.Build();
	}
}

