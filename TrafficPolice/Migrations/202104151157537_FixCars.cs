namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Status");
        }
    }
}
