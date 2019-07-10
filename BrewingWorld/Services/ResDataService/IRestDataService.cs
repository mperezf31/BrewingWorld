using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrewingWorld.Models;

namespace BrewingWorld.Services
{
    public interface IRestDataService
    {

        Task<BaseListResponse<Beer>> GetBeerList();

        Task<BaseListResponse<Brewery>> GetBreweriesList(string beerId);

    }


}
