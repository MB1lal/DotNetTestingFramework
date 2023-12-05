using DotNetTestingFramework.Models.Config_Model;
using NLog;
using System.Text.Json;

namespace DotNetTestingFramework.Utils
{
    public class Configuration
    {
        public WebBrowser WebBrowser { get; set; }
        public Urls Urls { get; set; }

        public static Configuration LoadConfiguration(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                Configuration configuration = JsonSerializer.Deserialize<Configuration>(json);
                return configuration;
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                var config = new NLog.Config.XmlLoggingConfiguration("NLog.config");
                LogManager.Configuration = config;
                logger.Error($"Error loading configuration: {ex.Message}");
                return null;
            }
        }

    }
}
