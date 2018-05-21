namespace Examiner.Infrastructure.Migrations
{
    using Examiner.Core.DomainModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Examiner.Infrastructure.Data.ExaminerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Examiner.Infrastructure.Data.ExaminerDBContext context)
        {
            base.Seed(context);
        }
    }
}
