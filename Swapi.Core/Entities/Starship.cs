using Newtonsoft.Json;

namespace Swapi.Core.Entities
{
    public class Starship : BaseEntity
    {
        [JsonProperty]
        public string Name { get; set; }

        protected override string UrlPath => "/starships";
    }
}
