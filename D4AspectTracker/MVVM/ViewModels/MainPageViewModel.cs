using Microsoft.Maui.Controls;
using D4AspectTracker.MVVM.Views;

namespace D4AspectTracker.MVVM.ViewModels
{
    public class MainPageViewModel
    {
        public string UserName
        {
            get;
            set;
        }

        public MainPageViewModel()
        {
            // TODO delete this is just for testing
            UserName = "Test User Triscuit";
        }

        public void OnBtnExamineAspectsClicked(object o , EventArgs e)
        {
            INavigation navigation = App.Current.MainPage.Navigation;
            navigation.PushAsync(new MainAspectPageView());
        }



   

    }
}
