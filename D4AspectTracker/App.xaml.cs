using D4AspectTracker.MVVM.Views;

namespace D4AspectTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AspectListView();
	}
}
