namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDRaports : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Raports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RaportText = c.String(),
                        StaffID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.StaffID)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Raports", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.Raports", "CarID", "dbo.Cars");
            DropIndex("dbo.Raports", new[] { "CarID" });
            DropIndex("dbo.Raports", new[] { "StaffID" });
            DropTable("dbo.Raports");
        }
    }
}
