namespace Examiner.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamepropinTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "Name");
        }
    }
}
