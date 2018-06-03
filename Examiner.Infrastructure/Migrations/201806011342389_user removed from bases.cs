namespace Examiner.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userremovedfrombases : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionBases", "ApplicationUserId", "dbo.Users");
            DropForeignKey("dbo.TestBases", "ApplicationUserId", "dbo.Users");
            DropIndex("dbo.QuestionBases", new[] { "ApplicationUserId" });
            DropIndex("dbo.TestBases", new[] { "ApplicationUserId" });
            RenameColumn(table: "dbo.QuestionBases", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.TestBases", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AlterColumn("dbo.QuestionBases", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.TestBases", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.QuestionBases", "ApplicationUser_Id");
            CreateIndex("dbo.TestBases", "ApplicationUser_Id");
            AddForeignKey("dbo.QuestionBases", "ApplicationUser_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.TestBases", "ApplicationUser_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestBases", "ApplicationUser_Id", "dbo.Users");
            DropForeignKey("dbo.QuestionBases", "ApplicationUser_Id", "dbo.Users");
            DropIndex("dbo.TestBases", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.QuestionBases", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.TestBases", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.QuestionBases", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.TestBases", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.QuestionBases", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            CreateIndex("dbo.TestBases", "ApplicationUserId");
            CreateIndex("dbo.QuestionBases", "ApplicationUserId");
            AddForeignKey("dbo.TestBases", "ApplicationUserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionBases", "ApplicationUserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
