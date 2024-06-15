using Helpers.Common;
using LocalStorage.Contratcs.DAL;
using Sequrity.Contracts.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sequrity.Core.BLL
{
    public class AuthSequrityLogic : IAuthSequrityLogic
    {
        private readonly ILocalStorageDao _localStorageDao;

        public AuthSequrityLogic(ILocalStorageDao localStorageDao)
        {
            _localStorageDao = localStorageDao;
        }


        public void CipherServerCredentions(string url, string token)
        {
            if (_localStorageDao != null)
            {
                var key = _localStorageDao.GetAesKey();
                var iv = _localStorageDao.GetAesIV();
                if (key == null || iv == null)
                {
                    using (var aes = Aes.Create())
                    {
                        key = aes.Key;
                        iv = aes.IV;
                        _localStorageDao.SaveAesCredentions(key, iv);
                    }
                }
                _localStorageDao.SaveServerCredentions(url, CryptographyHelper.Encrypt(token, key, iv));
            }
        }

        public string DecipherServerCredentions()
        {
            // TODO
            // получем key и iv
            // пытаемся расшифровать токен
            // если успех - возврат токен
            // иначе null
            if (_localStorageDao != null)
            {
                
            }
            return "";
        }

        public void CipherLocalCredentions(string pin)
        {
            if (_localStorageDao != null)
            {
                _localStorageDao.SaveLocalCredentions(pin);
            }
        }

        public string DeCipherLocalCredentions()
        {
            return "";
        }

        public void CipherSystemCredentions()
        {
            if (_localStorageDao != null)
            {
                _localStorageDao.SaveSystemCredentions();
            }
        }

        public void DeCipherSystemCredentions()
        {

        }
        
    }
}
