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


        protected override void OnAppearing()
        {
            base.OnAppearing();

            Animation animation = new Animation(a => BeerImage.RotationX = a, 0, 360);
            animation.Commit(this, "ImageAnimation", 5, 1000, Easing.SinInOut, (arg1, arg2) => { BeerImage.RotationX = 0; }, () => false);

        }

    }
}
