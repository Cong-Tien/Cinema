namespace AloneBirds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewCreateTicket : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "State", c => c.String());
        }
    }
}
