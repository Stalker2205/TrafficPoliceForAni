namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDTPAndDTPCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DtpCars",
                c => new
                    {
                        DtpCarID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Voditel = c.String(),
                        DtpID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DtpCarID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Dtps", t => t.DtpID, cascadeDelete: true)
                .Index(t => t.CarID)
                .Index(t => t.DtpID);
            
            CreateTable(
                "dbo.Dtps",
                c => new
                    {
                        DtpID = c.Int(nullable: false, identity: true),
                        Addres = c.String(),
                        DateDtp = c.DateTime(nullable: false),
                        AccidentWitnesses = c.String(),
                        StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DtpID)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dtps", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.DtpCars", "DtpID", "dbo.Dtps");
            DropForeignKey("dbo.DtpCars", "CarID", "dbo.Cars");
            DropIndex("dbo.Dtps", new[] { "StaffID" });
            DropIndex("dbo.DtpCars", new[] { "DtpID" });
            DropIndex("dbo.DtpCars", new[] { "CarID" });
            DropTable("dbo.Dtps");
            DropTable("dbo.DtpCars");
        }
    }
}
