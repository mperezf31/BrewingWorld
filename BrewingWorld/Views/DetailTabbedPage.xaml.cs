﻿using BrewingWorld.Models;
using BrewingWorld.ViewModels;
using Xamarin.Forms;

namespace BrewingWorld.Views
{
    public partial class DetailTabbedPage : TabbedPage
    {

        public DetailTabbedPage(DetailTabbedViewModel viewModel)
        {
            BindingContext = viewModel;
            Title = viewModel.Title;

            Children.Add(new BeerDetailPage(viewModel.BeerDetailViewModel));
            Children.Add(new BreweryListViewPage(viewModel.BreweryListViewModel));

        }
    }
}
