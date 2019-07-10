using System;
namespace BrewingWorld
{
    public static class Constants
    {
        public const string Token = "260813f147e40ae66d0ca39e78e854d1";
        public const string BaseUrl = "https://sandbox-api.brewerydb.com/v2/";

        public const string GetBeersUrl = "beers/?key="+Token;
        public const string GetBreweriesUrl = "beer/{0}/breweries?key=" + Token;
        public const string GetBreweryDetailUrl = "brewery/{0}/?key=" + Token;


    }
}
