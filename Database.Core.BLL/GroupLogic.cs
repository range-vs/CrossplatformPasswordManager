using Database.Contracts.BLL;
using Database.Contracts.DAL;
using Entities.Common;
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
            // TODO: запрашиваем у DAL все сущности, кастим с помощью автомаппера в модели и возвращаем PL
            var result = await _groupDbDao.GetAll();
            List<GroupModel> collection = new List<GroupModel>();
            foreach (var entity in result)
            {
                collection.Add(new GroupModel { Id = entity.Id, Name = entity.Name });
            }
            return collection;
        }

        public async Task WriteConcurrent(GroupModel entity)
        {
            // TODO: кастим модель в сущность с помощью автомаппера и отправляем в DAL
            // пока имитация
            await Task.Delay(1000);
        }

    }
}
