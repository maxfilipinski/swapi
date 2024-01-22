using System.Text.Json.Serialization;

namespace Swapi.Core.Entities
{
    public class Person : BaseEntity
    {
        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }

        public string Created { get; set; }

        public string Edited { get; set; }

        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }

        [JsonPropertyName("films")]
        public IEnumerable<string> FilmUrls { get; set; }

        public string Gender { get; set; }

        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; }

        public string Height { get; set; }

        public string Homeworld { get; set; }

        public string Mass { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; }

        public IEnumerable<string> Species { get; set; }

        [JsonPropertyName("starships")]
        public IEnumerable<string> StarshipUrls { get; set; }

        public string Url { get; set; }

        [JsonPropertyName("vehicles")]
        public IEnumerable<string> VehicleUrls { get; set; }

        protected override string UrlPath => "/people";
    }
}
