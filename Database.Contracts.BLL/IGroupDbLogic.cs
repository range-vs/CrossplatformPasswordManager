using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Contracts.BLL
{
    public interface IGroupDbLogic
    {
        Task<IEnumerable<GroupModel>> GetAll();

        Task Write(IEnumerable<GroupModel> data);

    }
}
