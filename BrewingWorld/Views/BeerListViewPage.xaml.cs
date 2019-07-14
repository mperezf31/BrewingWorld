using BrewingWorld.Models;
using BrewingWorld.ViewModels;
using Xamarin.Forms;

namespace BrewingWorld.Views
{

    public partial class BeerListViewPage : ContentPage
    {

       private BeerListViewModel viewModel;


        public BeerListViewPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BeerListViewModel();

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Beer item))
                return;

            viewModel.SelectedBeer(item);
            // Manually deselect item.
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}
