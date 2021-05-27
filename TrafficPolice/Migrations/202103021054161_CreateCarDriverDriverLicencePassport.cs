namespace TrafficPolice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateCarDriverDriverLicencePassport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                {
                    CarID = c.Int(nullable: false, identity: true),
                    VenhicleType = c.String(),
                    EngineNumber = c.Int(nullable: false),
                    ChossisNumber = c.Int(nullable: false),
                    BodyNumber = c.Int(nullable: false),
                    Color = c.String(),
                    MaxVeigh = c.Int(nullable: false),
                    Vin = c.String(),
                    DriverID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Drivers", t => t.DriverID, cascadeDelete: true)
                .Index(t => t.DriverID);

            CreateTable(
                "dbo.Drivers",
                c => new
                {
                    DriverID = c.Int(nullable: false, identity: true),
                    Photo = c.Binary(),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Patronymic = c.String(),
                })
                .PrimaryKey(t => t.DriverID);

            CreateTable(
                "dbo.DriversLicenses",
                c => new
                {
                    DriversLicenseID = c.Int(nullable: false, identity: true),
                    DriversLicenseNumber = c.Int(nullable: false),
                    DriversLicenseSeries = c.Int(nullable: false),
                    Category = c.String(),
                    DateStart = c.DateTime(nullable: false),
                    DateEnd = c.DateTime(nullable: false),
                    DriverID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.DriversLicenseID)
                .ForeignKey("dbo.Drivers", t => t.DriverID, cascadeDelete: true)
                .Index(t => t.DriverID);

            CreateTable(
                "dbo.Passports",
                c => new
                {
                    PassportID = c.Int(nullable: false),
                    PassportNumber = c.Int(nullable: false),
                    PassportSeries = c.Int(nullable: false),
                    PassportAdress = c.String(),
                    DateOfIssue = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.PassportID)
                .ForeignKey("dbo.Drivers", t => t.PassportID)
                .Index(t => t.PassportID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Passports", "PassportID", "dbo.Drivers");
            DropForeignKey("dbo.DriversLicenses", "DriverID", "dbo.Drivers");
            DropForeignKey("dbo.Cars", "DriverID", "dbo.Drivers");
            DropIndex("dbo.Passports", new[] { "PassportID" });
            DropIndex("dbo.DriversLicenses", new[] { "DriverID" });
            DropIndex("dbo.Cars", new[] { "DriverID" });
            DropTable("dbo.Passports");
            DropTable("dbo.DriversLicenses");
            DropTable("dbo.Drivers");
            DropTable("dbo.Cars");
        }
    }
}
