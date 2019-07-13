using System;
using BrewingWorld.Models;
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.Behaviors
{
    public class BeerDetailNavigationBehavior : Behavior<ListView>
    {
        private INavigationService navigationService;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            navigationService = DependencyService.Get<INavigationService>();

            bindable.ItemSelected += OnItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= OnItemSelected;
        }


        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Beer item))
                return;

            navigationService.NavigateToBeerDetail(item);

            // Manually deselect item.
            ((ListView)sender).SelectedItem = null;
        }

    }
}
