namespace D4AspectTracker.MVVM.Views;

public partial class AddAspectTemplateView : ContentPage
{
	public AddAspectTemplateView()
	{
		InitializeComponent();
	}

    private void RadioRangedRoll_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RangedRollEntry.IsVisible = e.Value;
        if (!e.Value)
        {
            MinRollValue.Text = "";
            MaxRollValue.Text = "";
        }
        
    }

    private void RadioSetValue_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Set values have no template value, so we don't need to dynamically show any new entry controls
        
    }

    private void RadioStaticValue_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        StaticValueEntry.IsVisible = e.Value;
        if(!e.Value)
        {
            StaticValue.Text = "";
        }

    }
}