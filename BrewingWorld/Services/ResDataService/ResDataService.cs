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
        public async Task<BaseListResponse<Beer>> GetBeerList()
        {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Constants.BaseUrl)
            };


            HttpResponseMessage message = await client.GetAsync(Constants.GetBeersUrl);
            string response = await message.Content.ReadAsStringAsync();
            BaseListResponse<Beer> result = JsonConvert.DeserializeObject<BaseListResponse<Beer>>(response);
            return result;
        }

        public async Task<BaseListResponse<Brewery>> GetBreweriesList(string beerId)
        {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Constants.BaseUrl)
            };

            String url = String.Format(Constants.GetBreweriesUrl, beerId);

            HttpResponseMessage message = await client.GetAsync(url);
            string response = await message.Content.ReadAsStringAsync();
            BaseListResponse<Brewery> result = JsonConvert.DeserializeObject<BaseListResponse<Brewery>>(response);

            if (result != null && result.Data != null)
            {
                //Get Brewery details
                List<Task<BaseResponse<Brewery>>> tasks = new List<Task<BaseResponse<Brewery>>>();

                foreach (var Brewery in result.Data)
                {
                    tasks.Add(GetBreweryDetail(Brewery.Id));
                }

                var responseTasks = await Task.WhenAll(tasks);
                result.Data.Clear();

                foreach (var responseBreweryDetail in responseTasks)
                {
                    if (result != null && result.Data != null)
                    {
                        result.Data.Add(responseBreweryDetail.Data);
                    }
                }

            }

            return result;

        }


        public async Task<BaseResponse<Brewery>> GetBreweryDetail(string BreweryId)
        {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Constants.BaseUrl)
            };


            String url = String.Format(Constants.GetBreweryDetailUrl, BreweryId);
            HttpResponseMessage message = await client.GetAsync(url);
            string response = await message.Content.ReadAsStringAsync();
            BaseResponse<Brewery> breweryDetail = JsonConvert.DeserializeObject<BaseResponse<Brewery>>(response);
            return breweryDetail;

        }
    }
}
