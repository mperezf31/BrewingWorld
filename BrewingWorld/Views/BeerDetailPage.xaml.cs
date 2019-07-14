using BrewingWorld.ViewModels;
using Xamarin.Forms;

namespace BrewingWorld.Views
{
    public partial class BeerDetailPage : ContentPage
    {

        private BeerDetailViewModel viewModel;

        public BeerDetailPage(BeerDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            Animation animation = new Animation(a => BeerImage.ScaleX = a, 0, 1);
            animation.Commit(this, "ImageAnimation", 5, 800, Easing.SinInOut, (arg1, arg2) => { BeerImage.ScaleX = 1; }, () => false);

            Animation animationDescription = new Animation(a => Description.Scale = a, 0.8, 1);
            animationDescription.Commit(this, "DescriptionAnimation", 5, 800, Easing.BounceOut, (arg1, arg2) => { Description.Scale = 1; }, () => false);

            Animation animationStyle = new Animation(a => Style.Scale = a, 0.8, 1);
            animationStyle.Commit(this, "StyleAnimation", 5, 800, Easing.BounceOut, (arg1, arg2) => { Style.Scale = 1; }, () => false);

        }

    }
}
