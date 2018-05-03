using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(conf =>
            {
                conf.AddProfile<ServicesProfile>();
            }).CreateMapper();
        }
    }

}
