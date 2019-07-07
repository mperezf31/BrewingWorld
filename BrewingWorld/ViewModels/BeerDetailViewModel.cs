using BrewingWorld.Models;
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.ViewModels
{


    public class BeerDetailViewModel : BaseViewModel
    {


        private readonly INavigationService navigationService;


        public Beer BeerData { get; set; }

        public BeerDetailViewModel()
        {

        }


        public BeerDetailViewModel(Beer item = null)
        {
            Title = item.Name;
            BeerData = item;

            navigationService = DependencyService.Get<INavigationService>();

        }



    }
}
