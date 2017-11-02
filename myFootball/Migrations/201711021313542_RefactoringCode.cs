namespace myFootball.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Birthday", c => c.String());
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Players", "Birthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Birthdate", c => c.String());
            AlterColumn("dbo.Players", "Name", c => c.String());
            DropColumn("dbo.Players", "Birthday");
        }
    }
}
