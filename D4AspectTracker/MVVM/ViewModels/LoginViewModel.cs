using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using D4AspectTracker.MVVM.Views;

namespace D4AspectTracker.MVVM.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand NavigateCommand { private set; get; }
    public ICommand UserSelectCommand { private set; get; }

    public LoginViewModel()
    {
        NavigateCommand = new Command(() => 
        {
            INavigation nav = App.Current.MainPage.Navigation;
            nav.PushAsync(new CreateUserView());
        });

        UserSelectCommand = new Command<string>(LoginAsUser);

        
    }

    private void LoginAsUser(string username)
    {
        // do something here to log in as user
        Debug.Print(username);

        // navigate to main page
        App.Current.MainPage.Navigation.PushAsync(new MainPageView());
    }
}
