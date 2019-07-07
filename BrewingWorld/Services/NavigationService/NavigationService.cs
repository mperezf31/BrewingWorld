using System;
using BrewingWorld.Models;
using BrewingWorld.Views;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(BrewingWorld.Services.NavigationService))]
namespace BrewingWorld.Services
{
    public class NavigationService : INavigationService
    {

        public void NavigateToBeerDetail(Beer beer)
        {
            Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}
