using Database.Contracts.BLL;
using Database.Contracts.DAL;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Core.BLL
{
    public class GroupServerLogic : IGroupServerLogic
    {
        private readonly IGroupServerDao _groupServerDao;

        public GroupServerLogic(IGroupServerDao groupServerDao)
        {
            _groupServerDao = groupServerDao;
        }

        public Task<IEnumerable<GroupModel>> GetAll()
        {
            // TODO: запрашиваем у DAL все сущности с сервера, кастим с помощью автомаппера в модели и возвращаем PL
            throw new NotImplementedException();
        }

        public Task Write(IEnumerable<GroupModel> data)
        {
            // TODO: кастим модели в сущности с помощью автомаппера по флагу НЕ_ЗАПИСАНО и отправляем в DAL на сервер
            throw new NotImplementedException();
        }
    }
}
