using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using BrewingWorld.Models;
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.ViewModels
{


    public class BeerListViewModel : BaseViewModel
    {


        public Command LoadItemsCommand;
        private readonly IRestDataService restDataService;
        private readonly INavigationService navigationService;

        private Beer itemData;


        public BeerListViewModel()
        {

            Title = "BrewingWorld";

            Items = new ObservableCollection<Beer>();

            LoadItemsCommand = new Command(ExecuteLoadBeersCommand);
            restDataService = DependencyService.Get<IRestDataService>();
            navigationService = DependencyService.Get<INavigationService>();

        }


        public ObservableCollection<Beer> Items { get; set; }


        public Beer ItemData
        {
            get { return itemData; }
            set
            {
                itemData = value;
                Beer selected = value;
                ItemData = null;
                if (selected != null)
                {
                    navigationService.NavigateToBeerDetail(selected);
                }

            }
        }


        private async void ExecuteLoadBeersCommand()
        {

            if (IsBusy)
                return;

            IsBusy = true;


            BaseResponse<Beer> response = await restDataService.GetBeerList();
            if (string.IsNullOrEmpty(response.ErrorMessage))
            {

                Items.Clear();
                List<Beer> items = response.Data;
                foreach (var item in items)
                {
                    Items.Add(item);
                }

            }
            else
            {
                Debug.WriteLine(response.ErrorMessage);
            }

            IsBusy = false;

        }

      
    }
}
