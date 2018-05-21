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
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public ExaminerDBContext()
            : base("name=ExaminerDBContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ExaminerDBContext>());
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
