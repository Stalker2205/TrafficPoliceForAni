namespace TrafficPolice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateInsurancePtc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurances",
                c => new
                {
                    InsuranceID = c.Int(nullable: false),
                    InsuranceNumber = c.Int(nullable: false),
                    InsuranceSeries = c.Int(nullable: false),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: false),
                    Insurant = c.String(),
                })
                .PrimaryKey(t => t.InsuranceID)
                .ForeignKey("dbo.Cars", t => t.InsuranceID)
                .Index(t => t.InsuranceID);

            CreateTable(
                "dbo.Ptcs",
                c => new
                {
                    PtcID = c.Int(nullable: false),
                    PtcNumber = c.Int(nullable: false),
                    PtcSeries = c.String(),
                    YearOfManufacture = c.Int(nullable: false),
                    EngineVolume = c.Int(nullable: false),
                    EngineType = c.String(),
                    EcoClass = c.String(),
                    Manufacture = c.String(),
                    CustomsRestrictions = c.String(),
                    DateOut = c.String(),
                })
                .PrimaryKey(t => t.PtcID)
                .ForeignKey("dbo.Cars", t => t.PtcID)
                .Index(t => t.PtcID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Ptcs", "PtcID", "dbo.Cars");
            DropForeignKey("dbo.Insurances", "InsuranceID", "dbo.Cars");
            DropIndex("dbo.Ptcs", new[] { "PtcID" });
            DropIndex("dbo.Insurances", new[] { "InsuranceID" });
            DropTable("dbo.Ptcs");
            DropTable("dbo.Insurances");
        }
    }
}
