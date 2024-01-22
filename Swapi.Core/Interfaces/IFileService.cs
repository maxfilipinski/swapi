namespace Swapi.Core.Interfaces
{
    public interface IFileService
    {
        void WriteToFile(object data, bool writeIndented = true);
    }
}
