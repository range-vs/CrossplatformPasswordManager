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
    public class GroupDbLogic : IGroupDbLogic
    {
        private readonly IGroupDbDao _groupDbDao;

        public GroupDbLogic(IGroupDbDao groupDbDao)
        {
            _groupDbDao = groupDbDao;
        }

        public async Task<IEnumerable<GroupModel>> GetAll()
        {
            // TODO: запрашиваем у DAL все сущности с диска, кастим с помощью автомаппера в модели и возвращаем PL
            var result = await _groupDbDao.GetAll();
            List<GroupModel> collection = new List<GroupModel>();
            foreach (var entity in result)
            {
                collection.Add(new GroupModel { Id = entity.Id, Name = entity.Name });
            }
            return collection;
        }

        public async Task Write(IEnumerable<GroupModel> data)
        {
            // TODO: кастим модели в сущности с помощью автомаппера и отправляем в DAL на диск
            // пока имитация
            await Task.Delay(1000);
        }

    }
}
