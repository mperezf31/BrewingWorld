using System;
using Newtonsoft.Json;

namespace BrewingWorld.Models
{
    public class Brewery
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "images")]
        public ImageList Images { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

    }
}