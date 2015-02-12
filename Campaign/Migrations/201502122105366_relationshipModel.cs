namespace CampaignMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParentChild", "ChildRefId", "dbo.Panels");
            DropForeignKey("dbo.ParentChild", "ParentRefId", "dbo.Panels");
            DropIndex("dbo.ParentChild", new[] { "ChildRefId" });
            DropIndex("dbo.ParentChild", new[] { "ParentRefId" });
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        RelationshipId = c.Int(nullable: false, identity: true),
                        ChildId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelationshipId);
            
            DropTable("dbo.ParentChild");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParentChild",
                c => new
                    {
                        ChildRefId = c.Int(nullable: false),
                        ParentRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChildRefId, t.ParentRefId });
            
            DropTable("dbo.Relationships");
            CreateIndex("dbo.ParentChild", "ParentRefId");
            CreateIndex("dbo.ParentChild", "ChildRefId");
            AddForeignKey("dbo.ParentChild", "ParentRefId", "dbo.Panels", "PanelId");
            AddForeignKey("dbo.ParentChild", "ChildRefId", "dbo.Panels", "PanelId");
        }
    }
}
