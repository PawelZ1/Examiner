namespace Examiner.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class domainclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestComponents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Root_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestComponents", t => t.Root_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Root_Id);
            
            CreateTable(
                "dbo.Users",
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
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QuestionBases",
                c => new
                    {
                        QuestionBaseId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        ApplicableFor = c.Guid(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.QuestionBaseId)
                .ForeignKey("dbo.Users", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TestBases",
                c => new
                    {
                        TestBaseId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        ApplicableFor = c.Guid(),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TestBaseId)
                .ForeignKey("dbo.Users", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Content = c.String(nullable: false),
                        ApplicableFor = c.Guid(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestComponents", t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApplicationUser_Id)
                .Index(t => t.Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuestionBaseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestComponents", t => t.Id)
                .ForeignKey("dbo.QuestionBases", t => t.QuestionBaseId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.QuestionBaseId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TestBaseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestComponents", t => t.Id)
                .ForeignKey("dbo.TestBases", t => t.TestBaseId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TestBaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "TestBaseId", "dbo.TestBases");
            DropForeignKey("dbo.Tests", "Id", "dbo.TestComponents");
            DropForeignKey("dbo.Questions", "QuestionBaseId", "dbo.QuestionBases");
            DropForeignKey("dbo.Questions", "Id", "dbo.TestComponents");
            DropForeignKey("dbo.Answers", "ApplicationUser_Id", "dbo.Users");
            DropForeignKey("dbo.Answers", "Id", "dbo.TestComponents");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.TestComponents", "UserId", "dbo.Users");
            DropForeignKey("dbo.TestBases", "ApplicationUserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.QuestionBases", "ApplicationUserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.TestComponents", "Root_Id", "dbo.TestComponents");
            DropIndex("dbo.Tests", new[] { "TestBaseId" });
            DropIndex("dbo.Tests", new[] { "Id" });
            DropIndex("dbo.Questions", new[] { "QuestionBaseId" });
            DropIndex("dbo.Questions", new[] { "Id" });
            DropIndex("dbo.Answers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Answers", new[] { "Id" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.TestBases", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.QuestionBases", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.TestComponents", new[] { "Root_Id" });
            DropIndex("dbo.TestComponents", new[] { "UserId" });
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            DropTable("dbo.Roles");
            DropTable("dbo.TestBases");
            DropTable("dbo.UserRoles");
            DropTable("dbo.QuestionBases");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.TestComponents");
        }
    }
}
