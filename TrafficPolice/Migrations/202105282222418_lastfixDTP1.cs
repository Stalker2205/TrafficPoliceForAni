namespace TrafficPolice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastfixDTP1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dtps", "NameOfScheme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dtps", "NameOfScheme", c => c.String());
        }
    }
}
