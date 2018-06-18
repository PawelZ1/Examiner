using AutoMapper;
using Examiner.Core.Profiles;
using Examiner.MvcClient.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(conf =>
            {
                conf.AddProfile<ServicesProfile>();
                conf.AddProfile<ControllerProfile>();
            }).CreateMapper();
        }
    }
}