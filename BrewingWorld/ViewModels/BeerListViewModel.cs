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


        private readonly IRestDataService restDataService;
        private readonly ISettingsService settingsService;
        private readonly INavigationService navigationService;

        private bool isRrefresh = false;


        public BeerListViewModel()
        {

            Title = "BrewingWorld";

            Items = new ObservableCollection<Beer>();

            LoadItemsCommand = new Command(() => ExecuteLoadBeersCommand(false));
            RrefreshItemsCommand = new Command(() => ExecuteLoadBeersCommand(true));

            settingsService = DependencyService.Get<ISettingsService>();
            navigationService = DependencyService.Get<INavigationService>();
            restDataService = DependencyService.Get<IRestDataService>();
        }


        public ObservableCollection<Beer> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command RrefreshItemsCommand { get; set; }


        public bool IsRrefresh
        {
            get { return isRrefresh; }
            set
            {
                isRrefresh = value;
                OnPropertyChanged();
            }
        }

        internal void SelectedBeer(Beer item)
        {
            item.Visited = true;

            settingsService.AddBeerVisited(item.Id);
            navigationService.NavigateToBeerDetail(item);

        }

        private async void ExecuteLoadBeersCommand(bool TryRefresh)
        {

            if (IsBusy || IsRrefresh)
                return;

            if (TryRefresh)
            {
                IsRrefresh = true;
            }
            else
            {
                IsBusy = true;
            }


            BaseListResponse<Beer> response = await restDataService.GetBeerList();
            if (string.IsNullOrEmpty(response.ErrorMessage))
            {

                Items.Clear();
                List<Beer> items = response.Data;
                foreach (var item in items)
                {
                    item.Visited = settingsService.BeerWasVisited(item.Id);
                    Items.Add(item);
                }

            }
            else
            {
                Debug.WriteLine(response.ErrorMessage);
            }


            IsRrefresh = false;
            IsBusy = false;

        }

    }

}
