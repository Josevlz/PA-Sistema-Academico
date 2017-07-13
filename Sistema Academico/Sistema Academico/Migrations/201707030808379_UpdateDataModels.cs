namespace Sistema_Academico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asignaturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreAsig = c.String(),
                        Codigo = c.String(),
                        Creditos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pensums",
                c => new
                    {
                        PensumId = c.Int(nullable: false, identity: true),
                        Desde = c.DateTime(nullable: false),
                        Hasta = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        Carrera_CarreraId = c.Int(),
                    })
                .PrimaryKey(t => t.PensumId)
                .ForeignKey("dbo.Carreras", t => t.Carrera_CarreraId)
                .Index(t => t.Carrera_CarreraId);
            
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        CarreraId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        CreditosRequeridos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarreraId);
            
            CreateTable(
                "dbo.PensumAsignaturas",
                c => new
                    {
                        Pensum_PensumId = c.Int(nullable: false),
                        Asignatura_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pensum_PensumId, t.Asignatura_Id })
                .ForeignKey("dbo.Pensums", t => t.Pensum_PensumId, cascadeDelete: true)
                .ForeignKey("dbo.Asignaturas", t => t.Asignatura_Id, cascadeDelete: true)
                .Index(t => t.Pensum_PensumId)
                .Index(t => t.Asignatura_Id);
            
            AddColumn("dbo.Estudiantes", "Carrera_CarreraId", c => c.Int());
            CreateIndex("dbo.Estudiantes", "Carrera_CarreraId");
            AddForeignKey("dbo.Estudiantes", "Carrera_CarreraId", "dbo.Carreras", "CarreraId");
            DropColumn("dbo.Estudiantes", "Carrera");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiantes", "Carrera", c => c.String());
            DropForeignKey("dbo.Estudiantes", "Carrera_CarreraId", "dbo.Carreras");
            DropForeignKey("dbo.Pensums", "Carrera_CarreraId", "dbo.Carreras");
            DropForeignKey("dbo.PensumAsignaturas", "Asignatura_Id", "dbo.Asignaturas");
            DropForeignKey("dbo.PensumAsignaturas", "Pensum_PensumId", "dbo.Pensums");
            DropIndex("dbo.PensumAsignaturas", new[] { "Asignatura_Id" });
            DropIndex("dbo.PensumAsignaturas", new[] { "Pensum_PensumId" });
            DropIndex("dbo.Estudiantes", new[] { "Carrera_CarreraId" });
            DropIndex("dbo.Pensums", new[] { "Carrera_CarreraId" });
            DropColumn("dbo.Estudiantes", "Carrera_CarreraId");
            DropTable("dbo.PensumAsignaturas");
            DropTable("dbo.Carreras");
            DropTable("dbo.Pensums");
            DropTable("dbo.Asignaturas");
        }
    }
}
