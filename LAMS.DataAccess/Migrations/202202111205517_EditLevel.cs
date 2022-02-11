namespace Ecology.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditLevel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Azot", "Level", c => c.String());
            AlterColumn("dbo.Ozon", "Level", c => c.String());
            AlterColumn("dbo.BioOxygen", "Level", c => c.String());
            AlterColumn("dbo.ChemicalOxygen", "Level", c => c.String());
            AlterColumn("dbo.Ph", "Level", c => c.String());
            AlterColumn("dbo.Pm", "Level", c => c.String());
            AlterColumn("dbo.Pm", "Level10", c => c.String());
            AlterColumn("dbo.Sera", "Level", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sera", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.Pm", "Level10", c => c.Int(nullable: false));
            AlterColumn("dbo.Pm", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.Ph", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.ChemicalOxygen", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.BioOxygen", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.Ozon", "Level", c => c.Int(nullable: false));
            AlterColumn("dbo.Azot", "Level", c => c.Int(nullable: false));
        }
    }
}
