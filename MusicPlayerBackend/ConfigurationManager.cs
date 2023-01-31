namespace MusicPlayerBackend
{
    public class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        protected internal static IConfiguration AzureConnectionStrings { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            AzureConnectionStrings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings_secret.json")
                .Build();
        }
    }
}
