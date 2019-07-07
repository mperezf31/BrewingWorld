using System.Diagnostics;
using System.Windows.Input;
using BrewingWorld.Models;
using BrewingWorld.Services;
using Xamarin.Forms;

namespace BrewingWorld.ViewModels
{
    public class AboutViewModel : BaseViewModel_old
    {

        private readonly IRestDataService restDataService;

        public AboutViewModel()
        {
            Title = "About";


            this.restDataService = DependencyService.Get<IRestDataService>();
            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            OpenWebCommand = new Command(() => GetBeers());

        }

        public ICommand OpenWebCommand { get; }


        public async void GetBeers() {

           BaseResponse<Beer> response = await restDataService.GetBeerList();
            if (string.IsNullOrEmpty(response.ErrorMessage)) {
                Debug.WriteLine(response.Data);

            }
            else {
                Debug.WriteLine(response.ErrorMessage);
            }


        }
    }
}