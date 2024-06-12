using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Contracts.BLL
{
    public interface IAuthLogic
    {
        Task<bool> CheckServerAuth(string url, string login, string password);
        bool TryServerAuth();
        bool CheckLocalAuth(string pin);
        bool TryLocalAuth(string pin);
        bool CheckSystemAuth();
        bool TrySystemAuth();
    }
}
