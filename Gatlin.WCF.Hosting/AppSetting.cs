using System.Configuration;

namespace Gatlin.WCF.Hosting
{
    public class AppSetting
    {
        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}
