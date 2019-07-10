using BrewingWorld.ViewModels;
using Xamarin.Forms;

namespace BrewingWorld.Views
{
    public partial class BreweryListViewPage : ContentPage
    {

        private readonly BreweryListViewModel viewModel;

        public BreweryListViewPage(BreweryListViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }



    }
}
