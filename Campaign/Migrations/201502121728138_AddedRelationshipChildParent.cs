namespace CampaignMaker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipChildParent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentChild",
                c => new
                    {
                        ChildRefId = c.Int(nullable: false),
                        ParentRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChildRefId, t.ParentRefId })
                .ForeignKey("dbo.Panels", t => t.ChildRefId)
                .ForeignKey("dbo.Panels", t => t.ParentRefId)
                .Index(t => t.ChildRefId)
                .Index(t => t.ParentRefId);
            
            DropColumn("dbo.Panels", "AdventureId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Panels", "AdventureId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ParentChild", "ParentRefId", "dbo.Panels");
            DropForeignKey("dbo.ParentChild", "ChildRefId", "dbo.Panels");
            DropIndex("dbo.ParentChild", new[] { "ParentRefId" });
            DropIndex("dbo.ParentChild", new[] { "ChildRefId" });
            DropTable("dbo.ParentChild");
        }
    }
}
