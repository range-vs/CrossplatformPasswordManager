using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Contracts.BLL
{
    public interface IGroupLogic
    {
        Task<IEnumerable<GroupModel>> GetAll();
        Task WriteConcurrent(GroupModel model);
    }
}
