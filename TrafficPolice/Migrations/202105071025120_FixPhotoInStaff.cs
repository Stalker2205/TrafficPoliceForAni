namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPhotoInStaff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Staffs", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "Photo", c => c.String());
        }
    }
}
