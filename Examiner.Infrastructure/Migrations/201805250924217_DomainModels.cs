namespace Examiner.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Guid(nullable: false),
                        AnswerContent = c.String(nullable: false, maxLength: 500),
                        IsCorrect = c.Boolean(nullable: false),
                        TestCategoryId = c.Guid(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.TestCategories", t => t.TestCategoryId)
                .Index(t => t.TestCategoryId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Guid(nullable: false),
                        QuestionContent = c.String(nullable: false),
                        TestCategoryId = c.Guid(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.TestCategories", t => t.TestCategoryId)
                .Index(t => t.TestCategoryId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TestCategories",
                c => new
                    {
                        TestCategoryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TestCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        TestCategoryId = c.Guid(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.TestCategories", t => t.TestCategoryId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.TestCategoryId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.QuestionTests",
                c => new
                    {
                        Question_QuestionId = c.Guid(nullable: false),
                        Test_TestId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionId, t.Test_TestId })
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.Test_TestId, cascadeDelete: true)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Test_TestId);
            
            CreateTable(
                "dbo.AnswerQuestions",
                c => new
                    {
                        Answer_AnswerId = c.Guid(nullable: false),
                        Question_QuestionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Answer_AnswerId, t.Question_QuestionId })
                .ForeignKey("dbo.Answers", t => t.Answer_AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .Index(t => t.Answer_AnswerId)
                .Index(t => t.Question_QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Answers", "TestCategoryId", "dbo.TestCategories");
            DropForeignKey("dbo.AnswerQuestions", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.AnswerQuestions", "Answer_AnswerId", "dbo.Answers");
            DropForeignKey("dbo.QuestionTests", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.QuestionTests", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "TestCategoryId", "dbo.TestCategories");
            DropForeignKey("dbo.TestCategories", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tests", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Questions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Answers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tests", "TestCategoryId", "dbo.TestCategories");
            DropIndex("dbo.AnswerQuestions", new[] { "Question_QuestionId" });
            DropIndex("dbo.AnswerQuestions", new[] { "Answer_AnswerId" });
            DropIndex("dbo.QuestionTests", new[] { "Test_TestId" });
            DropIndex("dbo.QuestionTests", new[] { "Question_QuestionId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Tests", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tests", new[] { "TestCategoryId" });
            DropIndex("dbo.TestCategories", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Questions", new[] { "TestCategoryId" });
            DropIndex("dbo.Answers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Answers", new[] { "TestCategoryId" });
            DropTable("dbo.AnswerQuestions");
            DropTable("dbo.QuestionTests");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tests");
            DropTable("dbo.TestCategories");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
