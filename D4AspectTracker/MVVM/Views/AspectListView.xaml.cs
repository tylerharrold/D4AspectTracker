using D4AspectTracker.MVVM.ViewModels;

namespace D4AspectTracker.MVVM.Views;

public partial class AspectListView : ContentPage
{

	private AspectListViewModel model;	

	public AspectListView()
	{
		InitializeComponent();

		model = new AspectListViewModel();

		BindingContext = model;
		AddTestData.Pressed += model.OnAddAnotherD4Aspect;
		
	}

	private void OnSearchBarPressed(object sender, EventArgs e)
	{
		// todo
	}

	private void OnAddTestDataPressed(object sender, EventArgs e)
	{
		
	}
}