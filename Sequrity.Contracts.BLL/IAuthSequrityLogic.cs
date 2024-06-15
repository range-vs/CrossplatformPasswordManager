using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequrity.Contracts.BLL
{
    public interface IAuthSequrityLogic
    {
        void CipherServerCredentions(string url, string token);
        string DecipherServerCredentions();

        void CipherLocalCredentions(string pin);
        string DeCipherLocalCredentions();
        void CipherSystemCredentions();
        void DeCipherSystemCredentions();


    }
}
