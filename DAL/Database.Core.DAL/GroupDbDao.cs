using Database.Contracts.DAL;
using Database.Contracts.NAL;
using Entities.Common;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Core.DAL
{
    public class GroupDbDao : IGroupDbDao
    {
        private readonly IGroupNetDao _groupNetDao;

        public GroupDbDao(IGroupNetDao groupNetDao)
        {
            _groupNetDao = groupNetDao;
        }

        public async Task<IEnumerable<GroupModel>> GetAll()
        {
            // TODO: запрашиваем у NAL все сущности и кастим их уже в model (MVVM) - с оомощью Automapper
            var result = await _groupNetDao.GetAll();
            List<GroupModel> collection = new List<GroupModel>();
            foreach (var entity in result) 
            {
                collection.Add(new GroupModel { Id = entity.Id, Name = entity.Name });
            }
            return collection;
        }

        public async Task WriteConcurrent(GroupModel entity)
        {
            // TODO: кастим модель в сущность и отправляем в NAL
            // пока имитация
            await Task.Delay(1000);
        }

    }
}
