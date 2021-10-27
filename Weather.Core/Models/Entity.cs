using Newtonsoft.Json;

namespace Weather.Core.Models
{
    public abstract class Entity
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
