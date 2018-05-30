using Autofac;
using Examiner.MvcClient.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            base.Load(builder); 
        }
    }
}