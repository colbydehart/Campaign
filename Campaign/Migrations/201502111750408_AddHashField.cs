namespace CampaignMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHashField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "Hash", x => x.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campains", "Hash");
        }
    }
}
