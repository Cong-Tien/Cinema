namespace AloneBirds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CategoryClient", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CategoryClient");
        }
    }
}
