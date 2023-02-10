namespace MusicPlayerBackend
{
    public class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        protected internal static IConfiguration SecretAppSettings { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            SecretAppSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings_secret.json")
                .Build();
        }
    }
}
