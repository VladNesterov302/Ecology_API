namespace Ecology.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWater : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BioOxygen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dose = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        IdWaterObject = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .ForeignKey("dbo.WaterObjects", t => t.IdWaterObject)
                .Index(t => t.IdWaterObject)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.ChemicalOxygen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dose = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        IdWaterObject = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .ForeignKey("dbo.WaterObjects", t => t.IdWaterObject)
                .Index(t => t.IdWaterObject)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Ph",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dose = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        IdWaterObject = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .ForeignKey("dbo.WaterObjects", t => t.IdWaterObject)
                .Index(t => t.IdWaterObject)
                .Index(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BioOxygen", "IdWaterObject", "dbo.WaterObjects");
            DropForeignKey("dbo.Ph", "IdWaterObject", "dbo.WaterObjects");
            DropForeignKey("dbo.Ph", "IdUser", "dbo.Users");
            DropForeignKey("dbo.ChemicalOxygen", "IdWaterObject", "dbo.WaterObjects");
            DropForeignKey("dbo.ChemicalOxygen", "IdUser", "dbo.Users");
            DropForeignKey("dbo.BioOxygen", "IdUser", "dbo.Users");
            DropIndex("dbo.Ph", new[] { "IdUser" });
            DropIndex("dbo.Ph", new[] { "IdWaterObject" });
            DropIndex("dbo.ChemicalOxygen", new[] { "IdUser" });
            DropIndex("dbo.ChemicalOxygen", new[] { "IdWaterObject" });
            DropIndex("dbo.BioOxygen", new[] { "IdUser" });
            DropIndex("dbo.BioOxygen", new[] { "IdWaterObject" });
            DropTable("dbo.Ph");
            DropTable("dbo.ChemicalOxygen");
            DropTable("dbo.BioOxygen");
        }
    }
}
