using D4AspectTracker.MVVM.ViewModels;
using D4AspectTracker.MVVM.Views;

namespace D4AspectTracker;

public partial class App : Application
{
	public static AddAspectViewModel AddAspectVM { get; private set; }

	public App(AddAspectViewModel aavm)
	{
		InitializeComponent();
        AddAspectVM = aavm;
        MainPage = new NavigationPage(new MainAspectPageView());

	}
}
