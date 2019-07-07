using BrewingWorld.Models;
using BrewingWorld.ViewModels;
using Xamarin.Forms;

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


        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Beer;
            if (item == null)
                return;

            viewModel.ItemSelected(item);
            
            // Manually deselect item.
            ((ListView)sender).SelectedItem = null;
        }


    }
}
