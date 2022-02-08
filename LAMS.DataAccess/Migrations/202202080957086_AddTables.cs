namespace Ecology.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Azot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dose = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        IdCity = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.IdCity)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdCity)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ozon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dose = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        IdCity = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.IdCity)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdCity)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Pm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dose = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        Dose10 = c.Double(nullable: false),
                        Level10 = c.Int(nullable: false),
                        IdCity = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.IdCity)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdCity)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Radiation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dose = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        IdCity = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.IdCity)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdCity)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Sera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dose = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        IdCity = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.IdCity)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdCity)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.WaterObjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WaterObject = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Azot", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Azot", "IdCity", "dbo.City");
            DropForeignKey("dbo.Ozon", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Sera", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Sera", "IdCity", "dbo.City");
            DropForeignKey("dbo.Radiation", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Radiation", "IdCity", "dbo.City");
            DropForeignKey("dbo.Pm", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Pm", "IdCity", "dbo.City");
            DropForeignKey("dbo.Ozon", "IdCity", "dbo.City");
            DropIndex("dbo.Sera", new[] { "IdUser" });
            DropIndex("dbo.Sera", new[] { "IdCity" });
            DropIndex("dbo.Radiation", new[] { "IdUser" });
            DropIndex("dbo.Radiation", new[] { "IdCity" });
            DropIndex("dbo.Pm", new[] { "IdUser" });
            DropIndex("dbo.Pm", new[] { "IdCity" });
            DropIndex("dbo.Ozon", new[] { "IdUser" });
            DropIndex("dbo.Ozon", new[] { "IdCity" });
            DropIndex("dbo.Azot", new[] { "IdUser" });
            DropIndex("dbo.Azot", new[] { "IdCity" });
            DropColumn("dbo.Users", "Status");
            DropTable("dbo.WaterObjects");
            DropTable("dbo.Sera");
            DropTable("dbo.Radiation");
            DropTable("dbo.Pm");
            DropTable("dbo.Ozon");
            DropTable("dbo.City");
            DropTable("dbo.Azot");
        }
    }
}
