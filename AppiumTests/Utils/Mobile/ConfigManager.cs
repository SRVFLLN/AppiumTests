using System.Text.Json;
using System.IO;
using System;

namespace AppiumTests.Utils.Mobile
{
    public static class ConfigManager
    {
        public static ConfigInstance Config { get; private set; }

        public static void InitializeConfig()
        {
            try
            {
                Logger.Info("Trying to get data form config file...");
                Config = JsonSerializer.Deserialize<ConfigInstance>(File.ReadAllText("../../../Resources/config.json"));
            }
            catch(Exception e) 
            {
                Logger.Error("An error occured when trying to get data form config file! " + e.Message);
            }
        }

        public class ConfigInstance
        {
            public string RemoteServerAddress { get; set; }
            public string DeviceName { get; set; }
            public string PlatformName { get; set; }
            public string PlatformVersion { get; set; }
            public string BrowserName { get; set; }
            public string BaseUrl { get; set; }
            public string AppActivity { get; set; }
            public string AppPackage { get; set; }
        }
    }
}
