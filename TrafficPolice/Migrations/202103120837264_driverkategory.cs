namespace TrafficPolice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class driverkategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverKategoryLicences",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Kategory = c.String(),
                    DateOfAssignment = c.DateTime(nullable: false),
                    DateExpiration = c.DateTime(nullable: false),
                    DriversLicenseID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DriversLicenses", t => t.DriversLicenseID, cascadeDelete: true)
                .Index(t => t.DriversLicenseID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.DriverKategoryLicences", "DriversLicenseID", "dbo.DriversLicenses");
            DropIndex("dbo.DriverKategoryLicences", new[] { "DriversLicenseID" });
            DropTable("dbo.DriverKategoryLicences");
        }
    }
}
