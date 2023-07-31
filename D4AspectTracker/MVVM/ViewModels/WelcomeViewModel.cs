using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using D4AspectTracker.MVVM.Views;


namespace D4AspectTracker.MVVM.ViewModels;

public class WelcomeViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;


    public ICommand NavButtonClicked { private set; get; }

    public WelcomeViewModel() 
    {
        //Action<Object> myAction = Navigate;
        NavButtonClicked = new Command<string>(Navigate);
            
    }


    private void Navigate(string  s)
    {
        INavigation navigation = App.Current.MainPage.Navigation;
        switch (s)
        {
            case "Login":
                
                navigation.PushAsync(new LoginView());
                break;
            case "ExamineAspects":
                navigation.PushAsync(new MainAspectPageView());
                break;
            default:
                break;
        }

    }
}
