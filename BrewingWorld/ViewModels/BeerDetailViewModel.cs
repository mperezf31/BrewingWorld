using BrewingWorld.Models;

namespace BrewingWorld.ViewModels
{


    public class BeerDetailViewModel : BaseViewModel
    {

        

        public Beer BeerData { get; set; }

        public BeerDetailViewModel()
        {

        }


        public BeerDetailViewModel(Beer item = null)
        {
            Title = "Details";
            BeerData = item;
        }


    }
}
