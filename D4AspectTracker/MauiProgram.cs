using Microsoft.Extensions.Logging;
using System.Text;
using D4AspectTracker.Utility;
using D4AspectTracker.MVVM.ViewModels;
using D4AspectTracker.MVVM.Models;
using System.Diagnostics;

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

		// TODO - uncomment
		//string dbPath = FileAccessHelper.GetLocalFilePath("d4aspect.db3");
		// TODO - delete, the following is for testing purposes
		string dbPath = @"V:\MAUI_db_testing\d4aspect_TESTING.db";
		
        // use dependency injection to add singleton AddAspectViewModel class to application
        builder.Services.AddSingleton<DBManager>(s => ActivatorUtilities.CreateInstance<DBManager>(s, dbPath));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
