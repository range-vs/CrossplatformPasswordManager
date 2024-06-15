using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorage.Contratcs.DAL
{
    public interface ILocalStorageDao
    {
        void SaveAesCredentions(byte[] key, byte[] iv);
        byte[] GetAesKey();
        byte[] GetAesIV();

        void SaveServerCredentions(string url, byte[] token);
        string GetServerUrl();
        byte[] GetServerToken();

        void SaveLocalCredentions(string pin);
        string GetPin();
        void SaveSystemCredentions();
        bool IsSystemSequrityEnable();


    }
}
