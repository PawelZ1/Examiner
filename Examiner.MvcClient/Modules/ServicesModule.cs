using Autofac;
using Examiner.Core.Interfaces;
using Examiner.Infrastructure.Repositories;
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
            builder.RegisterType<TestRepository>().As<ITestRepository>();
            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>();
            builder.RegisterType<AnswerRepository>().As<IAnswerRepository>();
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            base.Load(builder); 
        }
    }
}