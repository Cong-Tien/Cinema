namespace AloneBirds.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableMovie : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
