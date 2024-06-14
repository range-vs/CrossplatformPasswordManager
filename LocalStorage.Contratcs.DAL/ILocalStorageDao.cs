using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorage.Contratcs.DAL
{
    public interface ILocalStorageDao
    {
        void SaveServerCredentions(string token);
        string GetServerToken();
        string GetServerUrl();
        void SaveLocalCredentions(string pin);
        string GetPin();
        void SaveSystemCredentions();
        bool IsSystemSequrityEnable();


    }
}
