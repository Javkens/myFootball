namespace myFootball.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResultTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KindOfTestId = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                        Date = c.String(),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "PlayerID", "dbo.Players");
            DropIndex("dbo.Results", new[] { "PlayerID" });
            DropTable("dbo.Results");
        }
    }
}
