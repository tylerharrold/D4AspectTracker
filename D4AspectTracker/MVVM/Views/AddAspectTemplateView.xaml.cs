using System.Diagnostics;

namespace D4AspectTracker.MVVM.Views;

public partial class AddAspectTemplateView : ContentPage
{

    private string _aspectType;

	public AddAspectTemplateView()
	{
		InitializeComponent();
	}

    private void RadioRangedRoll_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _aspectType = "rangedrollvalue";
        TurnOnAddAspectButton();
        RangedRollEntry.IsVisible = e.Value;
        if (!e.Value)
        {
            MinRollValue.Text = "";
            MaxRollValue.Text = "";
        }
        
    }

    private void RadioSetValue_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _aspectType = "setvalue";
        TurnOnAddAspectButton();
        
    }

    private void RadioStaticValue_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _aspectType = "staticvalue";
        TurnOnAddAspectButton(); 
        StaticValueEntry.IsVisible = e.Value;
        if(!e.Value)
        {
            StaticValue.Text = "";
        }

    }

    private async void AddAspectButton_Clicked(object sender, EventArgs e)
    {
        // ensure all required data is entered, pop warning if not
        if (!IsAllDataEntered())
        {
            await DisplayAlert("Required Fields Missing", "Please enter all required fields.", "OK");
        }
        else
        {
            // if everything is all set we call to AddAspectViewModel.AddPerson() to add to db
            
        }




        // pop error message if we get error from db entry
    }

    private void TurnOnAddAspectButton()
    {
        if (!AddAspectButton.IsVisible)
        {
            AddAspectButton.IsVisible = true;
        }
    }

    // method for ensuring all data fields have been properly entered before triggering
    // a call for db insertion
    private bool IsAllDataEntered()
    {
        bool allDataEntered = false;

        // aspect name, aspect category, aspect type
        if (string.IsNullOrEmpty(AspectNameEntry.Text) ||
            AspectCategoryPicker.SelectedIndex < 0 ||
            string.IsNullOrEmpty(_aspectType))
        {
            return allDataEntered;
        }
       
        switch (_aspectType)
        {
            case "rangedrollvalue":
                if(string.IsNullOrEmpty(MinRollValue.Text) || string.IsNullOrEmpty(MaxRollValue.Text))
                {
                    return allDataEntered;
                }
                break;
            case "staticvalue":
                if (string.IsNullOrEmpty(StaticValue.Text))
                {
                    return allDataEntered;
                }
                break;
            default:
                break;
        }

        // all data has been entered
        allDataEntered = true;

        return allDataEntered;     
    }
}