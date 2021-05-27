namespace TrafficPolice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class fixDriverLicence : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DriversLicenses", "Category");
        }

        public override void Down()
        {
            AddColumn("dbo.DriversLicenses", "Category", c => c.String());
        }
    }
}
