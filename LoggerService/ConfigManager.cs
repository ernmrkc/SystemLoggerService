using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LoggerService
{
    internal class ConfigManager
    {
        public int GetLogInterval()
        {
            string interval = ConfigurationManager.AppSettings["LogInterval"];
            if(int.TryParse(interval, out int result))
            {
                return result;
            }
            return 60000; // Default interval value
        }

    }
}
