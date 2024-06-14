using LocalStorage.Contratcs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorage.Core.DAL
{
    public class LocalStorageDao : ILocalStorageDao
    {
        public void SaveServerCredentions(string token)
        {
            // TODO: записать зашифрованный токен со способом расшифровки в файл, но КРОССПЛАТФОРМЕННО
        }
        public string GetServerToken()
        {
            return "";
        }
        public string GetServerUrl()
        {
            return "";
        }

        public void SaveLocalCredentions(string pin)
        {
            // TODO: save from file crossplatform!!!
        }

        public string GetPin()
        {
            return "";
        }

        public void SaveSystemCredentions()
        {
            // TODO: save status for use system login
        }

        public bool IsSystemSequrityEnable()
        {
            return true;
        }
    }
}
