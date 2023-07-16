using D4AspectTracker.MVVM.ViewModels;
using System.Diagnostics;

namespace D4AspectTracker.MVVM.Views;

public partial class MainAspectPageView : ContentPage
{
    private AspectListViewModel aspectListViewModel;

	public MainAspectPageView()
	{
		InitializeComponent();

        aspectListViewModel = new AspectListViewModel();
        BindingContext = aspectListViewModel;
	}

    private void BtnAddNewAspect_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AddAspectTemplateView());
		
    }

    //TODO this is not having intended effect
    protected override void OnAppearing()
    {
        base.OnAppearing();
        aspectListViewModel.RefreshAllAspects();
    }
}