using System;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(BrewingWorld.Services.SettingsService))]
namespace BrewingWorld.Services
{
    public class SettingsService : ISettingsService
    {
        public void AddBeerVisited(string beerId)
        {
            Preferences.Set(beerId, true);
        }

        public bool BeerWasVisited(string beerId)
        {
            return Preferences.Get(beerId, false);
        }
    }
}
