namespace TrafficPolice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateCTC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ctcs",
                c => new
                {
                    CtcID = c.Int(nullable: false),
                    CtcNumber = c.Int(nullable: false),
                    CtcSeries = c.String(),
                    Owner = c.Int(nullable: false),
                    DateOfIssue = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CtcID)
                .ForeignKey("dbo.Cars", t => t.CtcID)
                .Index(t => t.CtcID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Ctcs", "CtcID", "dbo.Cars");
            DropIndex("dbo.Ctcs", new[] { "CtcID" });
            DropTable("dbo.Ctcs");
        }
    }
}
