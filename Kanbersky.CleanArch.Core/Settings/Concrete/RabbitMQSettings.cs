using Kanbersky.CleanArch.Core.Settings.Abstract;

namespace Kanbersky.CleanArch.Core.Settings.Concrete
{
    public class RabbitMQSettings : ISettings
    {
        public string HostName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
