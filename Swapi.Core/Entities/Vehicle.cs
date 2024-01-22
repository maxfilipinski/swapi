using Newtonsoft.Json;

namespace Swapi.Core.Entities
{
    public class Vehicle : BaseEntity
    {
        [JsonProperty]
        public string Name { get; set; }

        protected override string UrlPath => "/vehicles";
    }
}
