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
        public DbSet<TestVersion> TestVersions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionVersion> QuestionVersions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestComponent> TestComponents { get; set; }

        public ExaminerDBContext()
            : base("name=ExaminerDBContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ExaminerDBContext>());
            Configuration.LazyLoadingEnabled = true;
        }

        public static ExaminerDBContext Create()
        {
            return new ExaminerDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Users table
            var users = modelBuilder.Entity<ApplicationUser>();
            users.ToTable("Users");

            //Roles table
            var roles = modelBuilder.Entity<IdentityRole>();
            roles.ToTable("Roles");

            //User roles table
            var userRoles = modelBuilder.Entity<IdentityUserRole>();
            userRoles.ToTable("UserRoles");

            //User logins table
            var userLogins = modelBuilder.Entity<IdentityUserLogin>();
            userLogins.ToTable("UserLogins");

            //User claims table
            var userClaims = modelBuilder.Entity<IdentityUserClaim>();
            userClaims.ToTable("UserClaims");

            //Test components table
            var testComponents = modelBuilder.Entity<TestComponent>();
            testComponents.ToTable("TestComponents");
            testComponents.HasMany(p => p.Components).WithOptional(p => p.Root);

            //Tests table
            var tests = modelBuilder.Entity<Test>();
            tests.ToTable("Tests");
            tests.HasKey(p => p.TestId);
            tests.HasRequired(p => p.User).WithMany(p => p.Tests).HasForeignKey(p => p.UserId);
            tests.Property(p => p.Content).IsRequired().HasMaxLength(10000);
            tests.Ignore(p => p.ApplicableFor);
            
            //Test versions table
            var testVersions = modelBuilder.Entity<TestVersion>();
            testVersions.ToTable("TestVersions");
            testVersions.HasKey(p => p.Id);
            testVersions.Property(p => p.Name).IsRequired().HasMaxLength(1000);
            testVersions.HasRequired(p => p.Test).WithMany(p => p.TestVersions).HasForeignKey(p => p.TestId);
            testVersions.Property(p => p.CreatedAt).IsRequired();
            testVersions.Property(p => p.UpdatedAt).IsRequired();

            //Questions table
            var questions = modelBuilder.Entity<Question>();
            questions.ToTable("Questions");
            questions.HasKey(p => p.QuestionId);
            questions.HasOptional(p => p.User).WithMany(p => p.Questions).HasForeignKey(p => p.UserId);
            questions.HasRequired(p => p.Test).WithMany(p => p.Questions).HasForeignKey(p => p.ApplicableFor);
            questions.Property(p => p.Content).IsRequired().HasMaxLength(10000);
            questions.Property(p => p.ApplicableFor).IsRequired();

            //Question versions table
            var questionVersions = modelBuilder.Entity<QuestionVersion>();
            questionVersions.ToTable("QuestionVersions");
            questionVersions.HasKey(p => p.Id);
            questionVersions.HasRequired(p => p.Question).WithMany(p => p.QuestionVersions).HasForeignKey(p => p.QuestionId);

            //Answers table
            var answers = modelBuilder.Entity<Answer>();
            answers.ToTable("Answers");
            answers.HasKey(p => p.Id);
            answers.HasRequired(p => p.User).WithMany(p => p.Answers);
            answers.HasRequired(p => p.Question).WithMany(p => p.Answers).HasForeignKey(p => p.ApplicableFor).WillCascadeOnDelete(false);
            answers.Property(p => p.ApplicableFor).IsRequired();
            answers.Property(p => p.Content).IsRequired().HasMaxLength(5000);
            answers.Property(p => p.IsCorrect).IsRequired();
        }
    }
}
