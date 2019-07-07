using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BrewingWorld.Services

{
    public class BaseResponse<T>
    {
        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }

        [JsonProperty(PropertyName = "status")]
        public String Status { get; set; }

        [JsonProperty(PropertyName = "errorMessage")]
        public String ErrorMessage { get; set; }

    }
} 
