using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BrewingWorld.Models;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(BrewingWorld.Services.ResDataService))]
namespace BrewingWorld.Services
{
    public class ResDataService : IRestDataService
    {
        public ResDataService()
        {

        }

        public async Task<BaseResponse<Beer>> GetBeerList() {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Constants.BaseUrl)
            };


            HttpResponseMessage message =  await client.GetAsync("beers/?key=260813f147e40ae66d0ca39e78e854d1");
            string response = await message.Content.ReadAsStringAsync();
            BaseResponse<Beer> result = JsonConvert.DeserializeObject<BaseResponse<Beer>>(response);
            return result;
        }

    }
}
