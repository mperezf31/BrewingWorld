using System;
using Newtonsoft.Json;

namespace BrewingWorld.Models
{
    public class Beer
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "abv")]
        public string Abv { get; set; }

        [JsonProperty(PropertyName = "labels")]
        public ImageList Images { get; set; }

        [JsonProperty(PropertyName = "style")]
        public BeerStyle Style { get; set; }


    }
}