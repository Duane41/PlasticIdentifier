namespace PlasticIdentifier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigrationD5 : DbMigration
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
                "dbo.HardwareUsages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HardwareUsageId = c.Int(nullable: false),
                        SI_Unit = c.String(),
                        DataSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataSets", t => t.DataSet_Id)
                .Index(t => t.DataSet_Id);
            
            AddColumn("dbo.Images", "ImageSize", c => c.Double(nullable: false));
            AddColumn("dbo.Images", "IsPlastic", c => c.Boolean());
            AddColumn("dbo.DataSets", "AlgorithmId", c => c.Int());
            AddColumn("dbo.DataSets", "NumImages", c => c.Int(nullable: false));
            AddColumn("dbo.DataSets", "NumImagesPlastic", c => c.Int(nullable: false));
            AddColumn("dbo.DataSets", "NumImagesNotPlastic", c => c.Int(nullable: false));
            AddColumn("dbo.DataSets", "Name", c => c.String());
            AddColumn("dbo.DataSets", "Trained", c => c.Boolean(nullable: false));
            CreateIndex("dbo.DataSets", "AlgorithmId");
            AddForeignKey("dbo.DataSets", "AlgorithmId", "dbo.Algorithms", "AlgorithmId");
            DropColumn("dbo.Images", "Name");
            DropColumn("dbo.Images", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Size", c => c.Double(nullable: false));
            AddColumn("dbo.Images", "Name", c => c.String());
            DropForeignKey("dbo.HardwareUsages", "DataSet_Id", "dbo.DataSets");
            DropForeignKey("dbo.DataSets", "AlgorithmId", "dbo.Algorithms");
            DropIndex("dbo.HardwareUsages", new[] { "DataSet_Id" });
            DropIndex("dbo.DataSets", new[] { "AlgorithmId" });
            DropColumn("dbo.DataSets", "Trained");
            DropColumn("dbo.DataSets", "Name");
            DropColumn("dbo.DataSets", "NumImagesNotPlastic");
            DropColumn("dbo.DataSets", "NumImagesPlastic");
            DropColumn("dbo.DataSets", "NumImages");
            DropColumn("dbo.DataSets", "AlgorithmId");
            DropColumn("dbo.Images", "IsPlastic");
            DropColumn("dbo.Images", "ImageSize");
            DropTable("dbo.HardwareUsages");
            DropTable("dbo.Algorithms");
        }
    }
}
