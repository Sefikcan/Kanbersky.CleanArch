using Kanbersky.CleanArch.Core.Settings.Abstract;

namespace Kanbersky.CleanArch.Core.Settings.Concrete
{
    public class ApiSettings : ISettings
    {
        public string BaseAddress { get; set; }

        public string CatalogPath { get; set; }

        public string OrderPath { get; set; }

        public string BasketPath { get; set; }
    }
}
