using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using BrewingWorld.Models;
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.ViewModels
{


    public class BeerListViewModel : BaseViewModel
    {

        private bool isRrefresh = false;


        public BeerListViewModel()
        {

            Title = "BrewingWorld";

            Items = new ObservableCollection<Beer>();

            LoadItemsCommand = new Command(() => ExecuteLoadBeersCommand(false));
            RrefreshItemsCommand = new Command(() => ExecuteLoadBeersCommand(true));
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

            SettingsService.AddBeerVisited(item.Id);
            NavigationService.NavigateToBeerDetail(item);

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


            BaseListResponse<Beer> response = await RestDataService.GetBeerList();
            if (string.IsNullOrEmpty(response.ErrorMessage))
            {

                Items.Clear();
                List<Beer> items = response.Data;
                foreach (var item in items)
                {
                    item.Visited = SettingsService.BeerWasVisited(item.Id);
                    Items.Add(item);
                }

            }
            else
            {
                ShowErrorConection(response.ErrorMessage);
            }


            IsRrefresh = false;
            IsBusy = false;

        }


        private async void ShowErrorConection(string msg)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Error", msg, "Retry", "Cancel");
            if (result == true)
            {
                LoadItemsCommand.Execute(null);
            }

        }

    }

}
