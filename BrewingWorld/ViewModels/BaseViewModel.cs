
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.ViewModels
{
    public class BaseViewModel : BindableObject
    {

        bool isBusy = false;
        string title = string.Empty;
       
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }


        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public ISettingsService SettingsService => DependencyService.Get<ISettingsService>();
        public INavigationService NavigationService => DependencyService.Get<INavigationService>();
        public IRestDataService RestDataService => DependencyService.Get<IRestDataService>();

    }
}
