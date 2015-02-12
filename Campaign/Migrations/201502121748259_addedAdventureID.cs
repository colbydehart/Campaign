namespace CampaignMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAdventureID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Panels", "AdventureId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Panels", "AdventureId");
        }
    }
}
