using Entities.Common;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Contracts.DAL
{
    public interface IGroupDbDao
    {
        Task<IEnumerable<GroupEntity>> GetAll();
        Task WriteConcurrent(GroupEntity model);
    }
}
