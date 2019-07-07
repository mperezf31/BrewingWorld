using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BrewingWorld.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrewingWorld.Views
{

    public partial class BeerListViewPage : ContentPage
    {


        BeerListViewModel viewModel;


        public BeerListViewPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BeerListViewModel();


        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }


    }
}
