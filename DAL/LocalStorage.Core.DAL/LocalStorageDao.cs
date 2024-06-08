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
        public void SaveServerCredentions(string url, string login, string password)
        {
            // TODO: save from file crossplatform!!!
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
