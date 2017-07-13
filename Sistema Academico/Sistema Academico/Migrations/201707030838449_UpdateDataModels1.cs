namespace Sistema_Academico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataModels1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pensums", "Hasta", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pensums", "Hasta", c => c.DateTime(nullable: false));
        }
    }
}
