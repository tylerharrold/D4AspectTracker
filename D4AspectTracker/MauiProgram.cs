using Microsoft.Extensions.Logging;
using System.Text;
using D4AspectTracker.Utility;
using D4AspectTracker.MVVM.ViewModels;

namespace D4AspectTracker;

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

		// add string path to where db will be stored on disk
		string dbPath = FileAccessHelper.GetLocalFilePath("d4aspect.db3");
		// use dependency injection to add singleton AddAspectViewModel class to application
		builder.Services.AddSingleton<AddAspectViewModel>(s => ActivatorUtilities.CreateInstance<AddAspectViewModel>(s, dbPath));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
