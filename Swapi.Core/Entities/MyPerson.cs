namespace Swapi.Core.Entities
{
    public class MyPerson : Person
    {
        public IList<Film> FilmTitles { get; set; } = new List<Film>();
        public IList<Starship> StarshipNames { get; set; } = new List<Starship>();
        public IList<Vehicle> VehicleNames { get; set; } = new List<Vehicle>();

        protected override string UrlPath => "/people/1";
    }
}
