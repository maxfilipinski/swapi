using Swapi.Core.Entities;
using System.Text.Json;

namespace Swapi.Server.Services
{
    public class PeopleService : IPeopleService
    {
        public MyPerson? GetPerson()
        {
            var jsonFilePath = $"{Directory.GetParent(Environment.CurrentDirectory).FullName}\\Swapi.Core\\Data\\Json\\mypersondata.txt";
            var result = JsonSerializer.Deserialize<MyPerson>(File.ReadAllText(jsonFilePath));
            if (result == null)
                return null;

            return result;
        }
    }

    public interface IPeopleService
    {
        MyPerson? GetPerson();
    }
}
