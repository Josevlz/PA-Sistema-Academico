namespace Sistema_Academico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Preseleccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PreSeleccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Asignatura_Id = c.Int(),
                        Estudiante_Id = c.Int(),
                        Trimestre_TrimestreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Asignaturas", t => t.Asignatura_Id)
                .ForeignKey("dbo.Estudiantes", t => t.Estudiante_Id)
                .ForeignKey("dbo.Trimestres", t => t.Trimestre_TrimestreId)
                .Index(t => t.Asignatura_Id)
                .Index(t => t.Estudiante_Id)
                .Index(t => t.Trimestre_TrimestreId);
            
            CreateTable(
                "dbo.Trimestres",
                c => new
                    {
                        TrimestreId = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Periodo = c.String(),
                    })
                .PrimaryKey(t => t.TrimestreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreSeleccions", "Trimestre_TrimestreId", "dbo.Trimestres");
            DropForeignKey("dbo.PreSeleccions", "Estudiante_Id", "dbo.Estudiantes");
            DropForeignKey("dbo.PreSeleccions", "Asignatura_Id", "dbo.Asignaturas");
            DropIndex("dbo.PreSeleccions", new[] { "Trimestre_TrimestreId" });
            DropIndex("dbo.PreSeleccions", new[] { "Estudiante_Id" });
            DropIndex("dbo.PreSeleccions", new[] { "Asignatura_Id" });
            DropTable("dbo.Trimestres");
            DropTable("dbo.PreSeleccions");
        }
    }
}
