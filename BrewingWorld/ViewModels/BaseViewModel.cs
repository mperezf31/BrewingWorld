
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


    }
}
