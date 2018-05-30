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
        public DbSet<TestBase> TestBases { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<QuestionBase> QuestionBases { get; set; }
        public DbSet<Question> Questions { get; set; }
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
            testComponents.HasRequired(p => p.User).WithMany(p => p.TestComponents).HasForeignKey(p => p.UserId);
            testComponents.HasMany(p => p.Components).WithOptional(p => p.Root);
            

            //Test bases table
            var testBases = modelBuilder.Entity<TestBase>();
            testBases.ToTable("TestBases");
            testBases.HasKey(p => p.TestBaseId);
            testBases.Property(p => p.Content).IsRequired().HasMaxLength(10000);
            testBases.Property(p => p.ApplicableFor).IsOptional();
            testBases.HasRequired(p => p.User).WithMany(p => p.TestBases).HasForeignKey(p => p.ApplicationUserId);
            
            //Tests table
            var tests = modelBuilder.Entity<Test>();
            tests.ToTable("Tests");
            tests.HasKey(p => p.Id);
            tests.HasRequired(p => p.TestBase).WithMany(p => p.Tests).HasForeignKey(p => p.TestBaseId);

            //Question bases table
            var questionBases = modelBuilder.Entity<QuestionBase>();
            questionBases.ToTable("QuestionBases");
            questionBases.HasKey(p => p.QuestionBaseId);
            questionBases.Property(p => p.Content).IsRequired().HasMaxLength(10000);
            questionBases.Property(p => p.ApplicableFor).IsRequired();
            questionBases.HasRequired(p => p.User).WithMany(p => p.QuestionBases).HasForeignKey(p => p.ApplicationUserId);

            //Questions table
            var questions = modelBuilder.Entity<Question>();
            questions.ToTable("Questions");
            questions.HasKey(p => p.Id);
            questions.HasRequired(p => p.QuestionBase).WithMany(p => p.Questions).HasForeignKey(p => p.QuestionBaseId);

            //Answers table
            var answers = modelBuilder.Entity<Answer>();
            answers.ToTable("Answers");
            answers.HasKey(p => p.Id);
            answers.Property(p => p.ApplicableFor).IsRequired();
            answers.Property(p => p.Content).IsRequired().HasMaxLength(5000);
            answers.Property(p => p.IsCorrect).IsRequired();
        }
    }
}
