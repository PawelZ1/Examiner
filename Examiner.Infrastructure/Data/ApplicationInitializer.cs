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
            var user = userManager.FindByName("user1@email.com");

            TestBase testBase = new TestBase(Guid.NewGuid(), "C# Essentials", "77C443D6-A6AE-49BF-913B-35DD1B4E4B1A");
            QuestionBase questionBase = new QuestionBase(Guid.NewGuid(), "abstract method is ?", "77C443D6-A6AE-49BF-913B-35DD1B4E4B1A", testBase.TestBaseId);

            Test test = new Test(Guid.NewGuid(), testBase, "77C443D6-A6AE-49BF-913B-35DD1B4E4B1A");
            Question question = new Question(Guid.NewGuid(), questionBase, "77C443D6-A6AE-49BF-913B-35DD1B4E4B1A");
            Answer answer = new Answer(Guid.NewGuid(), "Method for override", questionBase.QuestionBaseId, true, "77C443D6-A6AE-49BF-913B-35DD1B4E4B1A");

            context.TestBases.AddOrUpdate(testBase);
            context.QuestionBases.AddOrUpdate(questionBase);

            question.Add(answer);
            test.Add(question);
            context.TestComponents.AddOrUpdate(test);

            context.SaveChanges();
        }
    }
}
