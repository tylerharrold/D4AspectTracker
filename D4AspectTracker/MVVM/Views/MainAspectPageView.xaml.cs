using D4AspectTracker.MVVM.ViewModels;
using System.Diagnostics;

namespace D4AspectTracker.MVVM.Views;

public partial class MainAspectPageView : ContentPage
{
	public MainAspectPageView()
	{
		InitializeComponent();

		BindingContext = new AspectListViewModel();
	}

    private void BtnAddNewAspect_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AddAspectTemplateView());
		
    }
}