using Database.Contracts.NAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Core.NAL
{
    public class GroupNetDao: IGroupNetDao
    {
        private readonly IGroupNetDao _groupNetDao;

        public GroupNetDao(IGroupNetDao groupNetDao)
        {
            _groupNetDao = groupNetDao;
        }

        public void GetAll()
        {
            // TODO: заменить вовзращаемый тип, поместить его в Entities
        }
    }
}
