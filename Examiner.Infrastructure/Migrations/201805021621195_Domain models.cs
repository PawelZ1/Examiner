namespace Examiner.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Domainmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Guid(nullable: false),
                        AnswerContent = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Guid(nullable: false),
                        QuestionContent = c.String(),
                        TestId = c.Guid(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.TestId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Guid(nullable: false),
                        Name = c.String(),
                        Category = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Questions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Tests", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "TestId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
