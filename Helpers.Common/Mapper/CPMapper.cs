using AutoMapper;
using Helpers.Common.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Common.Mapper
{
    public class CPMapper: ICPMapper
    {
        public IMapper MapperProperty { get; set; }
        public CPMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            MapperProperty = config.CreateMapper();
        }

        public IMapper GetMapper()
        {
            return MapperProperty;
        }
    }
}
