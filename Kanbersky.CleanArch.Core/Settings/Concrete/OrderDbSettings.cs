using Kanbersky.CleanArch.Core.Settings.Abstract;

namespace Kanbersky.CleanArch.Core.Settings.Concrete
{
    public class OrderDbSettings : ISettings
    {
        public string ConnectionStrings { get; set; }
    }
}
