namespace MusicPlayerBackend
{
    public class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        protected internal static IConfiguration AzureConnectionString { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            AzureConnectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings_secret.json")
                .Build();
        }
    }
}
