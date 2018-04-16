namespace Examiner.Infrastructure.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Examiner.Core.DomainModels;

    public partial class ExaminerDBContext : IdentityDbContext<ApplicationUser>
    {
        public ExaminerDBContext()
            : base("name=ExaminerDBContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ExaminerDBContext>());
            Configuration.LazyLoadingEnabled = false;
        }

        public static ExaminerDBContext Create()
        {
            return new ExaminerDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
