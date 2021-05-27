namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCarRaports : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Raports", "CarID", "dbo.Cars");
            DropIndex("dbo.Raports", new[] { "CarID" });
            DropColumn("dbo.Raports", "CarID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Raports", "CarID", c => c.Int(nullable: false));
            CreateIndex("dbo.Raports", "CarID");
            AddForeignKey("dbo.Raports", "CarID", "dbo.Cars", "CarID", cascadeDelete: true);
        }
    }
}
