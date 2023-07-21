using D4AspectTracker.MVVM.ViewModels;
using System.Diagnostics;

namespace D4AspectTracker.MVVM.Views;

public partial class MainPageView : ContentPage
{
    private MainPageViewModel _viewModel;

	public MainPageView()
	{
        _viewModel = new MainPageViewModel();

        InitializeComponent();
        BindingContext = _viewModel;
        btnExamineAspects.Clicked += _viewModel.OnBtnExamineAspectsClicked;
        btnAddRoll.Clicked += _viewModel.OnBtnAddRoll;
    }

 
}