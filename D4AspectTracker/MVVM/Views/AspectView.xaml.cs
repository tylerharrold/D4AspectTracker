using D4AspectTracker.MVVM.ViewModels;

namespace D4AspectTracker.MVVM.Views;

public partial class AspectView : ContentPage
{
	public AspectView()
	{
        InitializeComponent();

        BindingContext = new AspectViewModel();
	}

    private void OnSearchBarPressed(object sender, EventArgs e)
    {
        // todo
    }
}