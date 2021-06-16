namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastfixDTP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dtps", "NameOfScheme", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dtps", "NameOfScheme");
        }
    }
}
