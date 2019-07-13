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

    }
}
