﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using BrewingWorld.Models;
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.ViewModels
{


    public class BreweryListViewModel : BaseViewModel
    {



        private readonly IRestDataService restDataService;

        public BreweryListViewModel()
        {
            Title = "Breweries";
            Items = new ObservableCollection<Brewery>();
            restDataService = DependencyService.Get<IRestDataService>();
        }


        public ObservableCollection<Brewery> Items { get; set; }


        public async void GetBreweries(string beerId)
        {

            if (IsBusy)
                return;

            IsBusy = true;


            BaseListResponse<Brewery> response = await restDataService.GetBreweriesList(beerId);
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
                Debug.WriteLine(response.ErrorMessage);
            }

            IsBusy = false;

        }

    }
}