namespace TrafficPolice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateInspectionStatments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inspections",
                c => new
                {
                    InspectionID = c.Int(nullable: false, identity: true),
                    RegistrationNumber = c.String(),
                    EndDate = c.DateTime(nullable: false),
                    PlaceOfInspaction = c.String(),
                    Vin = c.String(),
                    ChossisNumber = c.Int(nullable: false),
                    BodyNumber = c.Int(nullable: false),
                    Model = c.String(),
                    Malfunctions = c.String(),
                    UsingCar = c.Boolean(nullable: false),
                    CarID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.InspectionID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);

            CreateTable(
                "dbo.Statements",
                c => new
                {
                    StatementsID = c.Int(nullable: false, identity: true),
                    Applicant = c.String(),
                    Cause = c.String(),
                    Act = c.String(),
                    CarID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.StatementsID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Statements", "CarID", "dbo.Cars");
            DropForeignKey("dbo.Inspections", "CarID", "dbo.Cars");
            DropIndex("dbo.Statements", new[] { "CarID" });
            DropIndex("dbo.Inspections", new[] { "CarID" });
            DropTable("dbo.Statements");
            DropTable("dbo.Inspections");
        }
    }
}
