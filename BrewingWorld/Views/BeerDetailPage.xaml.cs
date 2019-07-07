using BrewingWorld.ViewModels;
using Xamarin.Forms;

namespace BrewingWorld.Views
{
    public partial class BeerDetailPage : ContentPage
    {

        BeerDetailViewModel viewModel;

        public BeerDetailPage(BeerDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

    }
}
