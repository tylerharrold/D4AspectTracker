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

    protected override void OnAppearing()
    {
        Debug.Print("got here"); 
        base.OnAppearing();
        aspectListViewModel.RefreshAllAspects();
    }
}