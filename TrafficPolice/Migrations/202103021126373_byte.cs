namespace TrafficPolice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _byte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drivers", "Photo", c => c.Binary());
        }

        public override void Down()
        {
            AlterColumn("dbo.Drivers", "Photo", c => c.String());
        }
    }
}
