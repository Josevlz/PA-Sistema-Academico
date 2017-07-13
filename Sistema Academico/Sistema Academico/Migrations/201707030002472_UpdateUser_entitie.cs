namespace Sistema_Academico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser_entitie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estudiantes", "Condicion", c => c.String());
            AddColumn("dbo.Estudiantes", "Carrera", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Apellidos", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Estudiantes", "Condition");
            DropColumn("dbo.Estudiantes", "career");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiantes", "career", c => c.String());
            AddColumn("dbo.Estudiantes", "Condition", c => c.String());
            DropColumn("dbo.AspNetUsers", "Apellidos");
            DropColumn("dbo.AspNetUsers", "Nombre");
            DropColumn("dbo.Estudiantes", "Carrera");
            DropColumn("dbo.Estudiantes", "Condicion");
        }
    }
}
