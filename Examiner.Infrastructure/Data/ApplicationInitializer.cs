using Examiner.Core.DomainModels;
using Examiner.Infrastructure.IdentityServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Infrastructure.Data
{
    public class ApplicationInitializer
    {
        public void InitializeUser(ApplicationUserManager userManager)
        {
            var user = new ApplicationUser
            {
                Id = "77C443D6-A6AE-49BF-913B-35DD1B4E4B1A",
                UserName = "user1@email.com",
                Email = "user1@email.com"
            };

            if (userManager.FindByName("user1@email.com") == null)
                userManager.Create(user, "Admin1");

        }

       public void InitializeData(ExaminerDBContext context, ApplicationUserManager userManager)
        {
            var user = userManager.FindByEmail("user1@email.com");

            Test CBase = new Test(Guid.NewGuid(), "C test Test base", user.Id);
            context.Tests.Add(CBase);
            Test JavaBase = new Test(Guid.NewGuid(), "JAVA test Test base", user.Id);
            context.Tests.Add(JavaBase);

            TestVersion Ctest = new TestVersion(Guid.NewGuid(), CBase, "C test - version 1");
            context.TestVersions.AddOrUpdate(Ctest);
            TestVersion Javatest = new TestVersion(Guid.NewGuid(), JavaBase, "Java test - version 1");
            context.TestVersions.AddOrUpdate(Javatest);

            Question questionBase1 = new Question(Guid.NewGuid(), "Sample question1", user.Id, CBase.TestId);
            context.Questions.AddOrUpdate(questionBase1);
            Question questionBase2 = new Question(Guid.NewGuid(), "Sample question1", user.Id, JavaBase.TestId);
            context.Questions.AddOrUpdate(questionBase2);

            QuestionVersion CQuestion1 = new QuestionVersion(Guid.NewGuid(), questionBase1);
            context.QuestionVersions.AddOrUpdate(CQuestion1);
            QuestionVersion CQuestion2 = new QuestionVersion(Guid.NewGuid(), questionBase1);
            context.QuestionVersions.AddOrUpdate(CQuestion2);
            QuestionVersion JavaQuestion1 = new QuestionVersion(Guid.NewGuid(), questionBase2);
            context.QuestionVersions.AddOrUpdate(JavaQuestion1);
            QuestionVersion JavaQuestion2 = new QuestionVersion(Guid.NewGuid(), questionBase2);
            context.QuestionVersions.AddOrUpdate(JavaQuestion2);

            //Ctest Answers
            Answer CAnswer1 = new Answer(Guid.NewGuid(), "Answer 1", questionBase1.QuestionId, true, user.Id);
            context.Answers.AddOrUpdate(CAnswer1);
            Answer CAnswer2 = new Answer(Guid.NewGuid(), "Answer 2", questionBase1.QuestionId, false, user.Id);
            context.Answers.AddOrUpdate(CAnswer2);
            Answer CAnswer3 = new Answer(Guid.NewGuid(), "Answer 3", questionBase1.QuestionId, true, user.Id);
            context.Answers.AddOrUpdate(CAnswer3);
            Answer CAnswer4 = new Answer(Guid.NewGuid(), "Answer 4", questionBase1.QuestionId, false, user.Id);
            context.Answers.AddOrUpdate(CAnswer4);
            Answer CAnswer5 = new Answer(Guid.NewGuid(), "Answer 5", questionBase1.QuestionId, false, user.Id);
            context.Answers.AddOrUpdate(CAnswer5);
            Answer CAnswer6 = new Answer(Guid.NewGuid(), "Answer 6", questionBase1.QuestionId, true, user.Id);
            context.Answers.AddOrUpdate(CAnswer6);

            //Javatest Answers
            Answer JavaAnswer1 = new Answer(Guid.NewGuid(), "Answer 1", questionBase2.QuestionId, false, user.Id);
            context.Answers.AddOrUpdate(JavaAnswer1);
            Answer JavaAnswer2 = new Answer(Guid.NewGuid(), "Answer 2", questionBase2.QuestionId, true, user.Id);
            context.Answers.AddOrUpdate(JavaAnswer2);
            Answer JavaAnswer3 = new Answer(Guid.NewGuid(), "Answer 3", questionBase2.QuestionId, false, user.Id);
            context.Answers.AddOrUpdate(JavaAnswer3);
            Answer JavaAnswer4 = new Answer(Guid.NewGuid(), "Answer 4", questionBase2.QuestionId, false, user.Id);
            context.Answers.AddOrUpdate(JavaAnswer4);
            Answer JavaAnswer5 = new Answer(Guid.NewGuid(), "Answer 5", questionBase2.QuestionId, true, user.Id);
            context.Answers.AddOrUpdate(JavaAnswer5);
            Answer JavaAnswer6 = new Answer(Guid.NewGuid(), "Answer 6", questionBase2.QuestionId, false, user.Id);
            context.Answers.AddOrUpdate(JavaAnswer6);

            CQuestion1.Add(CAnswer1);
            CQuestion1.Add(CAnswer2);
            CQuestion1.Add(CAnswer3);

            CQuestion2.Add(CAnswer4);
            CQuestion2.Add(CAnswer5);
            CQuestion2.Add(CAnswer6);

            JavaQuestion1.Add(JavaAnswer1);
            JavaQuestion1.Add(JavaAnswer2);
            JavaQuestion1.Add(JavaAnswer3);

            JavaQuestion2.Add(JavaAnswer4);
            JavaQuestion2.Add(JavaAnswer5);
            JavaQuestion2.Add(JavaAnswer6);

            Ctest.Add(CQuestion1);
            Ctest.Add(CQuestion2);
            Javatest.Add(JavaQuestion1);
            Javatest.Add(JavaQuestion2);

            context.TestComponents.AddOrUpdate(Ctest);
            context.TestComponents.AddOrUpdate(Javatest);

            context.SaveChanges();
        }
    }
}
