using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Modules
{
    public class DBModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExaminerDBContext>().AsSelf().InstancePerRequest();
            base.Load(builder);
        }
    }
}