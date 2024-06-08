using Database.Contracts.DAL;
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

        public async Task<IEnumerable<GroupEntity>> GetAll()
        {
            // TODO: запрашиваем все сущности с сервака, и передаем их в BLL
            await Task.Delay(3000);
            List<GroupEntity> collection = new List<GroupEntity>()
            {
                new()
                {
                    Id = 0,
                    Name = "Group 1"
                },
                new()
                {
                    Id = 1,
                    Name = "Group 2"
                },
                new()
                {
                    Id = 2,
                    Name = "Group 3"
                }
            };
            return collection;
        }

        public async Task WriteConcurrent(GroupEntity entity)
        {
            // TODO: отправляем на сервак
            // пока имитация
            await Task.Delay(1000);
        }

    }
}
