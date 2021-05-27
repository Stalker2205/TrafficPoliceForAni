namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDtpScheme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dtps", "DtpScheme", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dtps", "DtpScheme");
        }
    }
}
