using Newtonsoft.Json;

namespace Weather.Core.Models
{
    public class Weather : Entity
    {
        public string Name { get; set; }
        public MainInfo Main { get; set; }
        public Sys Sys { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
    }

    public class MainInfo : Entity
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        [JsonProperty("temp_min")]
        public double MinTemp { get; set; }
        [JsonProperty("temp_max")]
        public double MaxTemp { get; set; }
    }

    public class Wind : Entity
    {
        public double Speed { get; set; }
    }

    public class Clouds : Entity
    {
        [JsonProperty("all")]
        public int CloudsAll { get; set; }
    }

    public class Sys : Entity
    {
        public string Country { get; set; }
    }
}