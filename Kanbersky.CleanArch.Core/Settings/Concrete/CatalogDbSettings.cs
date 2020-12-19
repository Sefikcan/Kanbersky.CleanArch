using Kanbersky.CleanArch.Core.Settings.Abstract;

namespace Kanbersky.CleanArch.Core.Settings.Concrete
{
    public class CatalogDbSettings : ISettings
    {
        public string ConnectionStrings { get; set; }

        public string DatabaseName { get; set; }
    }
}
