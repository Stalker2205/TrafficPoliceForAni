namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDtpCars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DtpCars", "Conditions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DtpCars", "Conditions");
        }
    }
}
