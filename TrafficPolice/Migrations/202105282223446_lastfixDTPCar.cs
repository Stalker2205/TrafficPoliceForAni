namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastfixDTPCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DtpCars", "NameOfScheme", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DtpCars", "NameOfScheme");
        }
    }
}
