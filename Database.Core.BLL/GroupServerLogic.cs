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

        public async Task<IEnumerable<GroupModel>> GetAll()
        {
            // TODO: запрашиваем у DAL все сущности с сервера, кастим с помощью автомаппера в модели и возвращаем PL
            var result = await _groupServerDao.GetAll();
            List<GroupModel> collection = new List<GroupModel>();
            foreach (var entity in result)
            {
                collection.Add(new GroupModel { Id = entity.Id, Name = entity.Name });
            }
            return collection;
        }

        public async Task Write(IEnumerable<GroupModel> data)
        {
            // TODO: кастим модели в сущности с помощью автомаппера по флагу IsEdit и отправляем в DAL на сервер
            await Task.Delay(1000);
        }
    }
}
