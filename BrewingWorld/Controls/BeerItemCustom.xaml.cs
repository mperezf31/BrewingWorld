using BrewingWorld.Models;
using Xamarin.Forms;

namespace BrewingWorld.Controls
{
    public partial class BeerItemCustom : ContentView
    {


        public BeerItemCustom()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty BeerItemDataProperty = BindableProperty.Create(nameof(BeerItemData), typeof(Beer), typeof(BeerItemCustom), null);

        public Beer BeerItemData
        {

            get
            {
                return (Beer)GetValue(BeerItemDataProperty);
            }

            set
            {
                SetValue(BeerItemDataProperty, value);
            }

        }

    }
}
