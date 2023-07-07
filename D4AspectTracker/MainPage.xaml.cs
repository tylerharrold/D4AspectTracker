namespace D4AspectTracker;

public partial class MainPage : ContentPage
{

	// dummy data array
	//Aspect[] _aspects;
	//public Aspect[] Aspects { get { return _aspects; } }

	public MainPage()
	{
		// add in some dummy data --------------------------
		//_aspects = new Aspect[3];
		//Aspect a1 = new Aspect("Abundant Energy" , 30f, 40f);
		//a1.SetItemSlotModifier(ItemSlot.AMULET, 1.5f);
		//Aspect a2 = new Aspect("Inner Calm", 5.0f, 10.0f);
		//a2.SetItemSlotModifier(ItemSlot.AMULET, 1.5f);
		//Aspect a3 = new Aspect("Torment", 20f, 30f);

		//_aspects[0] = a1;
		//_aspects[1] = a2;
		//_aspects[2] = a3;

		// -------------------------------------------------

		InitializeComponent();
		BindingContext = this;


	}


	private void OnSearchBarPressed(object sender, EventArgs e)
	{
		// todo
	}
}

