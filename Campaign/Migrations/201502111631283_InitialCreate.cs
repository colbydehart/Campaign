namespace CampaignMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CampaignId);
            
            CreateTable(
                "dbo.Panels",
                c => new
                    {
                        PanelId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        CampaignId = c.Int(nullable: false),
                        AdventureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PanelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Panels");
            DropTable("dbo.Campaigns");
        }
    }
}
