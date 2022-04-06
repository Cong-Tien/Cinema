namespace AloneBirds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                        Release = c.DateTime(nullable: false),
                        Poster = c.String(),
                        Trailer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShowTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Room = c.String(),
                        Fare = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientsID = c.String(maxLength: 128),
                        Seat = c.String(),
                        Price = c.Double(nullable: false),
                        State = c.String(),
                        WatchingId = c.Byte(nullable: false),
                        Watching_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ClientsID)
                .ForeignKey("dbo.Watchings", t => t.Watching_Id)
                .Index(t => t.ClientsID)
                .Index(t => t.Watching_Id);
            
            CreateTable(
                "dbo.Watchings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowTimeId = c.Byte(nullable: false),
                        MovieId = c.Byte(nullable: false),
                        Movie_Id = c.Int(),
                        ShowTime_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .ForeignKey("dbo.ShowTimes", t => t.ShowTime_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.ShowTime_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Watching_Id", "dbo.Watchings");
            DropForeignKey("dbo.Watchings", "ShowTime_Id", "dbo.ShowTimes");
            DropForeignKey("dbo.Watchings", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Tickets", "ClientsID", "dbo.AspNetUsers");
            DropIndex("dbo.Watchings", new[] { "ShowTime_Id" });
            DropIndex("dbo.Watchings", new[] { "Movie_Id" });
            DropIndex("dbo.Tickets", new[] { "Watching_Id" });
            DropIndex("dbo.Tickets", new[] { "ClientsID" });
            DropTable("dbo.Watchings");
            DropTable("dbo.Tickets");
            DropTable("dbo.ShowTimes");
            DropTable("dbo.Movies");
        }
    }
}
