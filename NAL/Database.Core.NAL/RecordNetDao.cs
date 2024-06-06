using Database.Contracts.NAL;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Core.NAL
{
    public class RecordNetDao
    {
        private readonly IRecordNetDao _recordNetDao;

        public RecordNetDao(IRecordNetDao recordNetDao)
        {
            _recordNetDao = recordNetDao;
        }

        public async Task<IEnumerable<RecordEntity>> GetAll()    
        {
            // TODO: обращаемся к серверу асинхронно, получаем ответ и отправляем в PL
            // пока имитация сервера
            await Task.Delay(2000);
            return new List<RecordEntity>()
            {
                new()
                {
                    Id = 0,
                    Name = "Record 1",
                    Login = "login",
                    Password = "password",
                    TypeId = 0,
                    OtherData = "other data",
                    GroupId = 0
                },
                new()
                {
                    Id = 1,
                    Name = "Record 2",
                    Login = "login",
                    Password = "password",
                    TypeId = 1,
                    OtherData = "other data",
                    GroupId = 0
                },
                new()
                {
                    Id = 2,
                    Name = "Record 3",
                    Login = "login",
                    Password = "password",
                    TypeId = 0,
                    OtherData = "other data",
                    GroupId = 1
                },
                new()
                {
                    Id = 3,
                    Name = "Record 4",
                    Login = "login",
                    Password = "password",
                    TypeId = 1,
                    OtherData = "other data",
                    GroupId = 1
                }
            };
        }

        public async Task WriteConcurrent(RecordEntity entity)
        {
            // TODO: обращаемся к серверу асинхронно и отправляем туда данные, дожидаемся ответа асинхронно
            // пока имитация сервера
            await Task.Delay(1000);
        }
    }
}
