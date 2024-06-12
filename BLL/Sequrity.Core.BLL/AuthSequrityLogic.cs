﻿using LocalStorage.Contratcs.DAL;
using Sequrity.Contracts.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public void CipherServerCredentions(string token)
        {
            if (_localStorageDao != null)
            {
                _localStorageDao.SaveServerCredentions(token);
            }
        }

        public void CipherLocalCredentions(string pin)
        {
            if (_localStorageDao != null)
            {
                _localStorageDao.SaveLocalCredentions(pin);
            }
        }

        public void DeCipherLocalCredentions()
        {
            
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
