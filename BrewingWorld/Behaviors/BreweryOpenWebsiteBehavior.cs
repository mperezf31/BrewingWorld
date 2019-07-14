using System;
using BrewingWorld.Models;
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.Behaviors
{
    public class BreweryOpenWebsiteBehavior : Behavior<ListView>
    {

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.ItemSelected += OnItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= OnItemSelected;
        }


        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Brewery item) || string.IsNullOrEmpty(item.Website))
                return;

            Device.OpenUri(new Uri(item.Website));

            // Manually deselect item.
            ((ListView)sender).SelectedItem = null;
        }

    }
}
