using System;
using BrewingWorld.Models;

namespace BrewingWorld.ViewModels
{
    public class DetailTabbedViewModel: BaseViewModel
    {


        public BeerDetailViewModel BeerDetailViewModel { set; get; }
        public BreweryListViewModel BreweryListViewModel { set; get; }


        public DetailTabbedViewModel(Beer beer)
        {
            Title = beer.Name;

            BeerDetailViewModel = new BeerDetailViewModel(beer);
            BreweryListViewModel = new BreweryListViewModel(beer.Id);
        }

    
    }
}
