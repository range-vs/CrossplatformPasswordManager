﻿using Database.Contracts.NAL;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Core.NAL
{
    public class GroupNetDao: IGroupNetDao
    {

        public async Task<IEnumerable<GroupEntity>> GetAll()
        {
            // TODO: обращаемся к серверу асинхронно, получаем ответ и отправляем в PL
            // пока имитация сервера
            await Task.Delay(2000);
            return new List<GroupEntity>()
            {
                new()
                {
                    Id = 0,
                    Name = "Test1",
                },
                new()
                {
                    Id = 1,
                    Name = "Test2"
                }
            };       
        }

        public async Task WriteConcurrent(GroupEntity entity)
        {
            // TODO: обращаемся к серверу асинхронно и отправляем туда данные, дожидаемся ответа асинхронно
            // пока имитация сервера
            await Task.Delay(1000);
        }

    }
}
