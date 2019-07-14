using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using BrewingWorld.Models;
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.ViewModels
{


    public class BreweryListViewModel : BaseViewModel
    {


        public BreweryListViewModel(string beerId)
        {
            Title = "Breweries";
            Items = new ObservableCollection<Brewery>();

            GetBreweries(beerId);
        }


        public ObservableCollection<Brewery> Items { get; set; }


        public async void GetBreweries(string beerId)
        {

            if (IsBusy)
                return;

            IsBusy = true;


            BaseListResponse<Brewery> response = await RestDataService.GetBreweriesList(beerId);
            if (string.IsNullOrEmpty(response.ErrorMessage))
            {

                Items.Clear();
                List<Brewery> items = response.Data;
                foreach (var item in items)
                {
                    Items.Add(item);
                }

            }
            else
            {
                ShowErrorConection(response.ErrorMessage);
            }

            IsBusy = false;

        }

        private async void ShowErrorConection(string msg)
        {
            await Application.Current.MainPage.DisplayAlert("Error", msg, "Ok");     
        }

    }
}
