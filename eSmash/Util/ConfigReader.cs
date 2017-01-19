using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace eSmash.Util
{
    public static class ConfigReader
    {
        public static string getQlikConfigValue(string qlikKey)
        {
            //return ConfigurationManager.AppSettings["qlik-config." + qlikKey
            string turn = ConfigurationManager.AppSettings["qlik-config." + qlikKey];
            return turn;
        }
    }
}