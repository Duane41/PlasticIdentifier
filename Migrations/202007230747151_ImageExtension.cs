namespace PlasticIdentifier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageExtension : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Images", "ImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Images", "Size", c => c.Double(nullable: false));
            AddColumn("dbo.Images", "FileLocation", c => c.String());
            AddColumn("dbo.Images", "DateSet_Id", c => c.Int());
            CreateIndex("dbo.Images", "DateSet_Id");
            AddForeignKey("dbo.Images", "DateSet_Id", "dbo.DataSets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "DateSet_Id", "dbo.DataSets");
            DropIndex("dbo.Images", new[] { "DateSet_Id" });
            DropColumn("dbo.Images", "DateSet_Id");
            DropColumn("dbo.Images", "FileLocation");
            DropColumn("dbo.Images", "Size");
            DropColumn("dbo.Images", "ImageId");
            DropTable("dbo.DataSets");
        }
    }
}
