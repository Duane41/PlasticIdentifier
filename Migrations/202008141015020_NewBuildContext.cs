namespace PlasticIdentifier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewBuildContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Algorithms",
                c => new
                    {
                        AlgorithmId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AlgorithmId);
            
            CreateTable(
                "dbo.DataSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlgorithmId = c.Int(),
                        NumImages = c.Int(nullable: false),
                        NumImagesPlastic = c.Int(nullable: false),
                        NumImagesNotPlastic = c.Int(nullable: false),
                        Name = c.String(),
                        Trained = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Algorithms", t => t.AlgorithmId)
                .Index(t => t.AlgorithmId);
            
            CreateTable(
                "dbo.HardwareUsages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SI_Unit = c.String(),
                        DataSetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataSets", t => t.DataSetId, cascadeDelete: true)
                .Index(t => t.DataSetId);
            
            AddColumn("dbo.Images", "ImageSize", c => c.Double(nullable: false));
            AddColumn("dbo.Images", "FileLocation", c => c.String());
            AddColumn("dbo.Images", "IsPlastic", c => c.Boolean());
            AddColumn("dbo.Images", "DataSetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "DataSetId");
            AddForeignKey("dbo.Images", "DataSetId", "dbo.DataSets", "Id", cascadeDelete: true);
            DropColumn("dbo.Images", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Name", c => c.String());
            DropForeignKey("dbo.Images", "DataSetId", "dbo.DataSets");
            DropForeignKey("dbo.HardwareUsages", "DataSetId", "dbo.DataSets");
            DropForeignKey("dbo.DataSets", "AlgorithmId", "dbo.Algorithms");
            DropIndex("dbo.Images", new[] { "DataSetId" });
            DropIndex("dbo.HardwareUsages", new[] { "DataSetId" });
            DropIndex("dbo.DataSets", new[] { "AlgorithmId" });
            DropColumn("dbo.Images", "DataSetId");
            DropColumn("dbo.Images", "IsPlastic");
            DropColumn("dbo.Images", "FileLocation");
            DropColumn("dbo.Images", "ImageSize");
            DropTable("dbo.HardwareUsages");
            DropTable("dbo.DataSets");
            DropTable("dbo.Algorithms");
        }
    }
}
