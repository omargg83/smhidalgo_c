using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace smhidalgo
{
    class AppConfig
    {
        public static void Establecervalor(string pllave, string valor)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(pllave);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            config.AppSettings.Settings.Add(pllave, valor);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static string recuperarvalor(string pllave, string predeterminado)
        {
            string retorno = ConfigurationManager.AppSettings[pllave];
            if (retorno == null)
            {
                retorno = predeterminado;
            }
            return retorno;
        }
    }
}
