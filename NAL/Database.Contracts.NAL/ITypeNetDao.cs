using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Common;

namespace Database.Contracts.NAL
{
    public interface ITypeNetDao
    {
        Task<IEnumerable<TypeEntity>> GetAll();
        Task WriteConcurrent(TypeEntity entity);
    }
}
