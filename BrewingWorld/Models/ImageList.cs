using System;
using Newtonsoft.Json;

namespace BrewingWorld.Models
{
    public class ImageList
    {
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "medium")]
        public string Medium { get; set; }

        [JsonProperty(PropertyName = "large")]
        public string Large { get; set; }


    }
}
