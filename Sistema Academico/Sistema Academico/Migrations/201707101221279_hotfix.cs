namespace Sistema_Academico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PreSeleccions", "Tanda", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PreSeleccions", "Tanda");
        }
    }
}
