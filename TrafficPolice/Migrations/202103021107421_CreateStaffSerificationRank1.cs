namespace TrafficPolice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateStaffSerificationRank1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ranks",
                c => new
                {
                    RankID = c.Int(nullable: false, identity: true),
                    RankName = c.String(),
                    RankPhoto = c.String(),
                })
                .PrimaryKey(t => t.RankID);

            CreateTable(
                "dbo.Staffs",
                c => new
                {
                    StaffID = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    Lastname = c.String(),
                    Photo = c.Binary(),
                    Education = c.String(),
                    Login = c.String(),
                    Password = c.String(),
                    RankID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.StaffID)
                .ForeignKey("dbo.Ranks", t => t.RankID, cascadeDelete: true)
                .Index(t => t.RankID);

            CreateTable(
                "dbo.Sertifications",
                c => new
                {
                    SertificationID = c.Int(nullable: false, identity: true),
                    SertificationNumber = c.Int(nullable: false),
                    SertificationSeries = c.Int(nullable: false),
                    SertificationPosition = c.String(),
                    ValidUnit = c.DateTime(nullable: false),
                    StaffID = c.Int(),
                })
                .PrimaryKey(t => t.SertificationID)
                .ForeignKey("dbo.Staffs", t => t.StaffID)
                .Index(t => t.StaffID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "RankID", "dbo.Ranks");
            DropForeignKey("dbo.Sertifications", "Staff_StaffID", "dbo.Staffs");
            DropIndex("dbo.Sertifications", new[] { "Staff_StaffID" });
            DropIndex("dbo.Staffs", new[] { "RankID" });
            DropTable("dbo.Sertifications");
            DropTable("dbo.Staffs");
            DropTable("dbo.Ranks");
        }
    }
}
