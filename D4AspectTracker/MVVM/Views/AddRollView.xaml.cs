using D4AspectTracker.MVVM.ViewModels;

namespace D4AspectTracker.MVVM.Views;

public partial class AddRollView : ContentPage
{
	private AddRollViewModel _viewModel;

	public AddRollView()
	{
		InitializeComponent();

		// hook up to viewmodel
		_viewModel = new AddRollViewModel();
		BindingContext = _viewModel;

		// bind search bar to event handler in viewmodel
		schAspect.SearchButtonPressed += _viewModel.OnSearchButtonPressed;
	}
}