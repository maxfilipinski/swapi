namespace Swapi.Core.Entities
{
    public abstract class BaseEntity
    {
        protected abstract string UrlPath { get; }

        public string GetUrlPath()
        {
            return UrlPath;
        }
    }
}
