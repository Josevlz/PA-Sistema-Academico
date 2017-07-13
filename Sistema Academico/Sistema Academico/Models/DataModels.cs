using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace DataModels
{


    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellidos { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        //public virtual Profesor Profesor { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Estudiante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public double IndiceT { get; set; }
        public double IndiceG { get; set; }
        public string Condicion { get; set; }
        public virtual Carrera Carrera { get; set; }
        public ICollection<PreSeleccion> PreSeleccion { get; set; }
        //public ICollection<Asig_Cursada> Asig_Cursada { get; set; }

    }

    public class Asignatura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreAsig { get; set; }
        public virtual ICollection<Pensum> Pensum { get; set; }
        public string Codigo { get; set; }
        public int Creditos { get; set; }
        public ICollection<PreSeleccion> PreSeleccion { get; set; }
        //public virtual ICollection<OfertaAcad> OfertaAcad { get; set; }
    }

    public class Asig_Cursada
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        //public virtual OfertaAcad OfertaAcad { get; set; }
        public int Calificacion { get; set; }
    }

    public class Seccion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeccionId { get; set; }
        public Asignatura Asignatura { get; set; }
        public ApplicationUser Profesor { get; set; }
        public Aula Aula { get; set; }
        public Trimestre Trimestre { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }

    }

    public class Horario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public Seccion Seccion { get; set; }
    }

    public class Pensum
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PensumId { get; set; }
        public virtual Carrera Carrera { get; set; }
        public DateTime Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public virtual ICollection<Asignatura> Asignatura { get; set; }
        public bool Activo { get; set; }
        //public int TotalCreditos { get; set; }
    }

    public class Carrera
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarreraId { get; set; }
        public virtual ICollection<Pensum> Pensum { get; set; }
        public string Titulo { get; set; }
        public int CreditosRequeridos { get; set; }
    }

    public class OfertaAcad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfertaAcadId { get; set; }
        public Asignatura Asignatura { get; set; }
        public Trimestre Trimestre { get; set; }
        public virtual ICollection<Asig_Cursada> Asig_Cursada { get; set; }
    }

    public class Trimestre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrimestreId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Periodo { get; set; }
        //public virtual ICollection<OfertaAcad> OfertaAcad { get; set; }
        public ICollection<PreSeleccion> PreSeleccion { get; set; }
    }

    public class Profesor
    {
    }

    public class Aula
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NumeroAula { get; set; }
    }

    public class PreSeleccion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }
        public int? EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int? TrimestreId { get; set; }
        public Trimestre Trimestre { get; set; }
        public string Tanda { get; set; }
    }
    
}