using System;
using Newtonsoft.Json;

namespace BrewingWorld.Models
{
    public class BeerStyle
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}
