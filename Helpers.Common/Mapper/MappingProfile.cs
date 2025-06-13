using AutoMapper;
using Entities.Common;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GroupEntity, GroupModel>();
            CreateMap<GroupModel, GroupEntity>();
        }
    }
}
