using D4AspectTracker.MVVM.ViewModels;

namespace D4AspectTracker.MVVM.Views;

public partial class AspectListView : ContentPage
{
	public AspectListView()
	{
		InitializeComponent();

		BindingContext = new AspectListViewModel();
	}

	private void OnSearchBarPressed(object sender, EventArgs e)
	{
		// todo
	}
}