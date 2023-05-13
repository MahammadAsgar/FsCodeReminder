using Microsoft.Extensions.Configuration;

namespace FsCodeAplication
{
    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FsCodeApi"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("ConnectionStr");
            }
        }
    }
}
