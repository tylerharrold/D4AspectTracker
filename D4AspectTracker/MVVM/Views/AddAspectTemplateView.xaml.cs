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
            // need to quickly format numerical values
            double minVal, maxVal;
            minVal = FormatValue(MinRollValue.Text);
            maxVal = FormatValue(MaxRollValue.Text);
            App.AddAspectVM.AddNewD4Aspect(AspectNameEntry.Text , _aspectType , AspectCategoryPicker.SelectedItem.ToString() , 
                minVal , maxVal , StaticValue.Text);

            

            // TODO pop error message if we get error from db entry
        }
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


    // this function takes a string intended to represent a double and parses it into a double
    // HOWEVER any exceptions generated result in just formatting the string to 0.0. This is safe, but not ideal,
    // we should force correct entry in the case of a format exception, because user has made input error
    private double FormatValue(string s)
    {
        double val = 0.0;
        try
        {
            val = Double.Parse(s);
        }
        catch(Exception ex)
        {
           if(ex.InnerException is ArgumentNullException)
            {
                val = 0.0;  
            }
           if(ex.InnerException is FormatException)
            {
                val = 0.0;
            }
        }

        return val;
    }
}