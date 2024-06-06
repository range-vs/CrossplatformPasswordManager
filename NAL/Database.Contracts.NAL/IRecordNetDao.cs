using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Contracts.NAL
{
    public interface IRecordNetDao
    {
        Task<IEnumerable<RecordEntity>> GetAll();
        Task WriteConcurrent(RecordEntity entity);

    }
}
