using D4AspectTracker.MVVM.ViewModels;
using D4AspectTracker.MVVM.Models;
using System.Diagnostics;

namespace D4AspectTracker;

public partial class App : Application
{
	public static DBManager DBManager { get; private set; }

	public App(DBManager aavm)
	{
		InitializeComponent();
        DBManager = aavm;
        //MainPage = new NavigationPage(new D4AspectTracker.MVVM.Views.MainPage());
        MainPage = new NavigationPage(new D4AspectTracker.MVVM.Views.WelcomeView());

    }
}
