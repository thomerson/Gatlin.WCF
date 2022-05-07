using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
