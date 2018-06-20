using Autofac;
using Examiner.Core.Interfaces.Services;
using Examiner.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Modules
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QuestionService>().As<IQuestionService>();
            builder.RegisterType<AnswerService>().As<IAnswerService>();
            base.Load(builder);
        }
    }
}