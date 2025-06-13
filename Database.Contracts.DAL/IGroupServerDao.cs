using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Contracts.DAL
{
    public interface IGroupServerDao
    {
        Task<IEnumerable<GroupEntity>> GetAll();
        Task Write(GroupEntity model);
    }
}
