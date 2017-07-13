namespace Sistema_Academico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Preseleccion1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PreSeleccions", name: "Asignatura_Id", newName: "AsignaturaId");
            RenameColumn(table: "dbo.PreSeleccions", name: "Estudiante_Id", newName: "EstudianteId");
            RenameColumn(table: "dbo.PreSeleccions", name: "Trimestre_TrimestreId", newName: "TrimestreId");
            RenameIndex(table: "dbo.PreSeleccions", name: "IX_Asignatura_Id", newName: "IX_AsignaturaId");
            RenameIndex(table: "dbo.PreSeleccions", name: "IX_Estudiante_Id", newName: "IX_EstudianteId");
            RenameIndex(table: "dbo.PreSeleccions", name: "IX_Trimestre_TrimestreId", newName: "IX_TrimestreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PreSeleccions", name: "IX_TrimestreId", newName: "IX_Trimestre_TrimestreId");
            RenameIndex(table: "dbo.PreSeleccions", name: "IX_EstudianteId", newName: "IX_Estudiante_Id");
            RenameIndex(table: "dbo.PreSeleccions", name: "IX_AsignaturaId", newName: "IX_Asignatura_Id");
            RenameColumn(table: "dbo.PreSeleccions", name: "TrimestreId", newName: "Trimestre_TrimestreId");
            RenameColumn(table: "dbo.PreSeleccions", name: "EstudianteId", newName: "Estudiante_Id");
            RenameColumn(table: "dbo.PreSeleccions", name: "AsignaturaId", newName: "Asignatura_Id");
        }
    }
}
