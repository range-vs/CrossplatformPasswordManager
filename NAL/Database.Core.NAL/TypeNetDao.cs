using Database.Contracts.NAL;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Core.NAL
{
    public class TypeNetDao: ITypeNetDao
    {
        private readonly ITypeNetDao _typeNetDao;

        public TypeNetDao(ITypeNetDao typeNetDao)
        {
            _typeNetDao = typeNetDao;
        }

        public async Task<IEnumerable<TypeEntity>> GetAll()
        {
            // TODO: обращаемся к серверу асинхронно, получаем ответ и отправляем в PL
            // пока имитация сервера
            await Task.Delay(2000);
            return new List<TypeEntity>()
            {
                new()
                {
                    Id = 0,
                    Name = "Application",
                },
                new()
                {
                    Id= 1,
                    Name = "http/https"
                }
            };       
        }

        public async Task WriteConcurrent(TypeEntity entity)
        {
            // TODO: обращаемся к серверу асинхронно и отправляем туда данные, дожидаемся ответа асинхронно
            // пока имитация сервера
            await Task.Delay(1000);
        }

    }
}
