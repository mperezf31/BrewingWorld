using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace BrewingWorld.Models
{
    public class Beer : INotifyPropertyChanged
    {

        private Boolean visited = false;

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

        public bool Visited
        {
            get
            {
                return visited;
            }
            set
            {
                visited = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}