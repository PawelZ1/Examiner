namespace Examiner.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestNameisrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tests", "Name", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "Name", c => c.String());
        }
    }
}
