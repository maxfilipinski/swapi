using Newtonsoft.Json;

namespace Swapi.Core.Entities
{
    public class Film : BaseEntity
    {
        [JsonProperty]
        public string Title { get; set; }

        protected override string UrlPath => "/films";
    }
}
