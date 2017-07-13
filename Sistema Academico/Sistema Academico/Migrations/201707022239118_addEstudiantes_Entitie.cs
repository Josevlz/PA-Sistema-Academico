namespace Sistema_Academico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEstudiantes_Entitie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndiceT = c.Double(nullable: false),
                        IndiceG = c.Double(nullable: false),
                        Condition = c.String(),
                        career = c.String(),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estudiantes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Estudiantes", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Estudiantes");
        }
    }
}
