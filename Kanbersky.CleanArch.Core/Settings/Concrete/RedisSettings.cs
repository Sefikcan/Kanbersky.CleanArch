using Kanbersky.CleanArch.Core.Settings.Abstract;

namespace Kanbersky.CleanArch.Core.Settings.Concrete
{
    public class RedisSettings : ISettings
    {
        public string ConnectionStrings { get; set; }
    }
}
