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
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public ExaminerDBContext()
            : base("name=ExaminerDBContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ExaminerDBContext>());
            Configuration.LazyLoadingEnabled = true;
        }

        public static ExaminerDBContext Create()
        {
            return new ExaminerDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

            //Test categories table
            var testCategories = modelBuilder.Entity<TestCategory>();
            testCategories.ToTable("TestCategories");
            testCategories.HasRequired(p => p.User).WithMany(p => p.TestCategories).HasForeignKey(p => p.UserId);
            testCategories.Property(p => p.Name).IsRequired().HasMaxLength(300);
            testCategories.Property(P => P.CreatedAt).IsRequired();
            testCategories.Property(P => P.UpdatedAt).IsRequired();

            //Tests table
            var tests = modelBuilder.Entity<Test>();
            tests.ToTable("Tests");
            tests.HasOptional(p => p.TestCategory).WithMany(p => p.Tests).HasForeignKey(p => p.TestCategoryId);
            tests.Property(p => p.Name).IsRequired().HasMaxLength(300);

            //Questions table
            var questions = modelBuilder.Entity<Question>();
            questions.ToTable("Questions");
            questions.HasOptional(p => p.TestCategory).WithMany(p => p.Questions).HasForeignKey(p => p.TestCategoryId);
            questions.HasMany(p => p.Tests).WithMany(p => p.Questions);
            questions.Property(p => p.QuestionContent).IsRequired();

            //Answers table
            var answers = modelBuilder.Entity<Answer>();
            answers.ToTable("Answers");
            answers.HasOptional(p => p.TestCategory).WithMany(p => p.Answers).HasForeignKey(p => p.TestCategoryId);
            answers.HasMany(p => p.Questions).WithMany(p => p.Answers);
            answers.Property(p => p.AnswerContent).IsRequired().HasMaxLength(500);
            answers.Property(p => p.IsCorrect).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
