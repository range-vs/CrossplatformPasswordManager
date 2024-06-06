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
    public class GroupLogic : IGroupLogic
    {
        private readonly IGroupDbDao _groupDbDao;

        public GroupLogic(IGroupDbDao groupDbDao)
        {
            _groupDbDao = groupDbDao;
        }

        public async Task<IEnumerable<GroupModel>> GetAll()
        {
            // TODO: запрашиваем у DAL все модели и возвращаем PL
            var result = await _groupDbDao.GetAll();
            return result;
        }

        public async Task WriteConcurrent(GroupModel entity)
        {
            // TODO: запрашиваем у DAL все модели и возвращаем PL
            // пока имитация
            await Task.Delay(1000);
        }

    }
}
