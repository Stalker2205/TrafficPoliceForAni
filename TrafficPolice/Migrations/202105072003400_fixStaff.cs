namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixStaff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "Status");
        }
    }
}
