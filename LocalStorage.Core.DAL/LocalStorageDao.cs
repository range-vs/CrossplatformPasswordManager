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
        public void SaveAesCredentions(byte[] key, byte[] iv)
        {
            // TODO: пишем в закрытый файл(в ведре в закрытую область, в винде рядом с приложением)
        }
        public byte[] GetAesKey()
        {
            return null; // запрашиваем ключ кроссплатформенно и возвращаем
        }
        public byte[] GetAesIV()
        {
            return null; // запрашиваем iv кроссплатформенно и возвращаем
        }


        public void SaveServerCredentions(string url, byte[] token)
        {
            // TODO: записать зашифрованный токен со способом расшифровки в файл, но КРОССПЛАТФОРМЕННО
        }
        public string GetServerUrl()
        {
            return "";  // запрашиваем server url кроссплатформенно и возвращаем
        }
        public byte[] GetServerToken()
        {
            return null;  // запрашиваем зашифрованный токен кроссплатформенно и возвращаем
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
