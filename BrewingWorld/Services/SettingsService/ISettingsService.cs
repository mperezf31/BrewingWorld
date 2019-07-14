using System;
namespace BrewingWorld.Services
{
    public interface ISettingsService
    {
        void AddBeerVisited(string beerId);

        bool BeerWasVisited(string beerId);

    }
}
