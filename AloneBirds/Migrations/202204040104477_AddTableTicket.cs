namespace AloneBirds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seat = c.String(),
                        Price = c.Double(nullable: false),
                        ShowTimes = c.DateTime(nullable: false),
                        State = c.String(),
                        Room = c.String(),
                        ClientID = c.String(maxLength: 128),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ClientID)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.ClientID)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Tickets", "ClientID", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "Movie_Id" });
            DropIndex("dbo.Tickets", new[] { "ClientID" });
            DropTable("dbo.Tickets");
        }
    }
}
