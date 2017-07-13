using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DataModels;
//using static Sistema_Academico.Models.DataModels;

namespace Sistema_Academico.Models
{
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Pensum> Pensums { get; set; }
        public DbSet<Trimestre> Trimestres { get; set; }
        public DbSet<PreSeleccion> Preselecciones { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        #region FluentApi       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().Property(a => a.Nombre).IsRequired();
            modelBuilder.Entity<ApplicationUser>().Property(a => a.Apellidos).IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(e => e.Estudiante)
                .WithRequired(a => a.ApplicationUser);
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}