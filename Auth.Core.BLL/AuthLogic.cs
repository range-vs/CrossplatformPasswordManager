using Database.Contracts.DAL;
using LocalStorage.Contratcs.DAL;
using Models.Common;
using Sequrity.Contracts.BLL;
using Server.Contracts.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.BLL
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IAuthSequrityLogic _authSequrityLogic;
        private readonly ILocalStorageDao _localStorageDao;

        public AuthLogic(IAuthSequrityLogic authSequrityLogic, ILocalStorageDao localStorageDao)
        {
            _authSequrityLogic = authSequrityLogic;
            _localStorageDao = localStorageDao;
        }

        public async Task<bool> CheckServerAuth(string url, string login, string password)
        {
            // TODO: переделать на обращение к серверу
            await Task.Delay(4000);
            string token = "this_token";
            var status = false;
            if (_authSequrityLogic != null)
            {
                _authSequrityLogic.CipherServerCredentions(url, token);
                status = true;
            }
            return await Task.FromResult(status);
        }

        public bool TryServerAuth()
        {
            var status = false;
            if (_authSequrityLogic != null)
            {
                var token = _authSequrityLogic.DecipherServerCredentions();
                if (token != null || token != string.Empty)
                {
                    var isTokenValid = false;
                    // TODO: test connect to server
                    isTokenValid = true;
                    //
                    if(isTokenValid)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }

        public bool CheckLocalAuth(string pin)
        {
            // TODO запрос к Sequrity BLL (CipherLocalCredentions), корректен ли пин
            // выполняется первый раз всегда, обязательно
            return true;
        }

        public bool TryLocalAuth(string pin)
        {
            // TODO запрос к Sequrity BLL, а она уже обращается к localStorage
            // сравниваем, корректен ли пин
            // работает без инета
            return true;
        }

        public bool CheckSystemAuth()
        {
            // TODO запрос к Sequrity BLL (CipherSystemCredentions), корректно ли все в проверке Windows Hello или Android Sequrity
            // выполняется первый раз всегда, обязательно, но этого может и не быть (если систем без защиты)
            return true;
        }

        public bool TrySystemAuth()
        {
            // TODO запрос к Sequrity BLL, а она уже обращается к localStorage
            // сравниваем, верно ли мы сосканировали отпечаток или ввели пароль Win Hello или Android Sequrity
            // работает без инета
            // этапа может не быть, если в системе нет защиты
            return true;
        }
    }
}
