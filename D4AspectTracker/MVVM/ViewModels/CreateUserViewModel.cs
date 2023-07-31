
using System.ComponentModel;
using System.Windows.Input;
using D4AspectTracker.MVVM.Views;

namespace D4AspectTracker.MVVM.ViewModels;

public class CreateUserViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand NavigationCommand { get; private set; }

    public CreateUserViewModel()
    {
        NavigationCommand = new Command(() =>
        {
            // need to do more than just navigate here, this needs to talk to DB
            // but for now
            App.Current.MainPage.Navigation.PushAsync(new MainPageView());
        });

        
    }
}
