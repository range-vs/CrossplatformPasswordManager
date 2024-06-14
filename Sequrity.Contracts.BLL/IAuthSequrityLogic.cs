using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequrity.Contracts.BLL
{
    public interface IAuthSequrityLogic
    {
        void CipherServerCredentions(string token);
        void CipherLocalCredentions(string pin);
        void DeCipherLocalCredentions();
        void CipherSystemCredentions();
        void DeCipherSystemCredentions();


    }
}
