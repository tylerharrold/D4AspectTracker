namespace D4AspectTracker.MVVM.Views;

public partial class AddAspectTemplateView : ContentPage
{
	public AddAspectTemplateView()
	{
		InitializeComponent();
	}

    private void RadioRangedRoll_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
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
        TurnOnAddAspectButton();
        
    }

    private void RadioStaticValue_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        TurnOnAddAspectButton();
        StaticValueEntry.IsVisible = e.Value;
        if(!e.Value)
        {
            StaticValue.Text = "";
        }

    }

    private void AddAspectButton_Clicked(object sender, EventArgs e)
    {
        // ensure all required data is entered

        // pop up alert if necessary information is missing

        // if everything is all set we call to AddAspectViewModel.AddPerson() to add to db

        // pop error message if we get error from db entry
    }

    private void TurnOnAddAspectButton()
    {
        if (!AddAspectButton.IsVisible)
        {
            AddAspectButton.IsVisible = true;
        }
    }
}