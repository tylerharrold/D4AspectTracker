using D4AspectTracker.MVVM.ViewModels;
using System.Diagnostics;

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
		schAspect.TextChanged += _viewModel.OnSearchTextChanged;

		// bind collection view selection changed to handler
		collectionView.SelectionChanged += _viewModel.OnCollectionViewSelectionChanged;
		

	}

	private void ClearSearchBar(object sender , SelectionChangedEventArgs e)
	{
		schAspect.Text = string.Empty;
	}

	
}