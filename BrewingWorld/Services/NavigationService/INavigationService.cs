using BrewingWorld.Models;

namespace BrewingWorld.Services
{
    public interface INavigationService
    {

        void NavigateToBeerDetail(Beer beer);

        void NavigateToBreweries(string beerId);

    }


}
