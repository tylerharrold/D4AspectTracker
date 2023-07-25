using D4AspectTracker.MVVM.ViewModels;
using System.ComponentModel;
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

		// make text entry for ranged or set value listen for aspect selection
		_viewModel.RangeOrValueAspectSelected += ShowEntryIfRelevant;
		

	}

	
	// TODO reconsider whether this is worth it or not
	private void ClearSearchBar(object sender , SelectionChangedEventArgs e)
	{
		schAspect.Text = string.Empty;
	}


	// Method that listens for custom event fire on item selection. If the aspect selected is of the range or value type (i.e. it requires
	// a value entry) the form will make visible a text entry field. This method will also wipe the field of entry
	private void ShowEntryIfRelevant(string type)
	{
		// clear the field
		rangedValueEntry.Text = string.Empty;

		// see if we want to display field or not
		switch (type)
		{
			case "Range":
				rangedValueEntry.IsVisible = true;
				break;
			case "Value":
                rangedValueEntry.IsVisible = true;
				break;
			default:
                rangedValueEntry.IsVisible = false;
				return;

        }
	}

	// this button should only be enabled if the state of the form allows for it (aspect selected and value entered if appropriate)
    private async void btnAddRoll_Clicked(object sender, EventArgs e)
    {
		if (!NecessaryDataEntered())
		{
            await DisplayAlert("Required Fields Missing", "Please enter all required fields.", "OK");
		}
		else
		{
			// TODO this string should be sanitized and made to conform with selected aspect parameters
			// TODO this needs to restrics the values between possible ranges
			float value = 0.0f;
			if (!string.IsNullOrEmpty(rangedValueEntry.Text))
			{
				value = float.Parse(rangedValueEntry.Text);
			}
            _viewModel.AddRoll(value);
        }
		
		
    }

	// what an ugly method
	public bool NecessaryDataEntered()
	{

		// if there is a selection
		if(collectionView.SelectedItem != null)
		{
			// if the selection warrants a value entry
			if (rangedValueEntry.IsVisible)
			{
				// if the entry isn't empty
				if (!string.IsNullOrEmpty(rangedValueEntry.Text))
				{
					return true;
				}
				return false;
			}
			return true;
		}
		return false;
	}
}