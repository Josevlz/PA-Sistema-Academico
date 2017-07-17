using DataModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Sistema_Academico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sistema_Academico.ViewModel.EstudianteVM;
using Sistema_Academico.Repository;

namespace Sistema_Academico.Controllers
{
    [Authorize]
    public class EstudianteController : Controller
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
       

        public EstudianteController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: Estudiante
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentInfo()
        {
            Estudiante Estudiante = new Estudiante();
            var user = UserManager.FindById(User.Identity.GetUserId());
            using (var Dbcontext = new ApplicationDbContext())
            {
                Estudiante = Dbcontext.Estudiantes.Where(a => a.ApplicationUser.Id.Equals(user.Id)).FirstOrDefault();
                
            }
                //ApplicationUser usuario = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                return PartialView(Estudiante);
        }
        // Estudiante/Seleccion
        public ActionResult Seleccion()
        {
            
            return View();
        }
        // Estudiante/Asig_Pensum
        public ActionResult Asig_Pensum()
        {
            List<Asignatura> asignaturas = new List<Asignatura>();

            var user = UserManager.FindById(User.Identity.GetUserId());
            _Estudiante Repository = new _Estudiante(ApplicationDbContext);
            //var asg = new Pensum();
            ////Estudiante e = new Estudiante();
            //using (ApplicationDbContext DBContext = new ApplicationDbContext())
            //{
            //    var Estudiante = DBContext.Estudiantes.Where(a => a.ApplicationUser.Id.Equals(user.Id)).FirstOrDefault();
            //    var psn = DBContext.Pensums.Where(b => b.Carrera.CarreraId.Equals(Estudiante.Carrera.CarreraId)).FirstOrDefault();
            //    asg = DBContext.Pensums.Where(p => p.PensumId == psn.PensumId).Include(t => t.Asignatura).FirstOrDefault();

            //}
            return PartialView(Repository.Est_Pensum(Repository.GetId(user.Id)));
        }

        public ActionResult Pre_Seleccion()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            _Estudiante Repository = new _Estudiante(ApplicationDbContext);
            var a = Repository.GetId(user.Id);
            Repository.Est_Pensum(a);
            return View();
        }

        [HttpGet]
        public ActionResult PSTable(int? id, string tanda)
        {
            List<Asignatura> model;
            var Asig = ApplicationDbContext.Asignaturas.Where(a => a.Id == id).FirstOrDefault();

            Estudiante Estudiante = new Estudiante();
            var user = UserManager.FindById(User.Identity.GetUserId());
            using (var Dbcontext = new ApplicationDbContext())
            {
                Estudiante = Dbcontext.Estudiantes.Where(a => a.ApplicationUser.Id.Equals(user.Id)).FirstOrDefault();

            }
            var myPre = ApplicationDbContext.Preselecciones.Where(x => x.Estudiante.Id == Estudiante.Id).Select(a => a.Asignatura.Id).ToList();

            if (id == null){
               model = ApplicationDbContext.Asignaturas.Where(a => !myPre.Contains(a.Id)).ToList();
            }
            else
            {
                var Trim = ApplicationDbContext.Trimestres.FirstOrDefault();

                PreSeleccion Ps = new PreSeleccion
                {
                    AsignaturaId = Asig.Id,
                    EstudianteId = Estudiante.Id,
                    TrimestreId = Trim.TrimestreId,
                    Tanda= tanda

                };
                
                ApplicationDbContext.Entry(Ps).State = EntityState.Added;
                ApplicationDbContext.SaveChanges();               
                
                model = ApplicationDbContext.Asignaturas.Where(a=>!myPre.Contains(a.Id)).ToList();
            }


            return PartialView(model);
        }

        [HttpPost]
        public ActionResult PSTable( string name)
        {
            List<Asignatura> model;

            if (name == null)
            {
                model = ApplicationDbContext.Asignaturas.ToList();
            }
            else
            {
                //var PreSeleccion = from ps in ApplicationDbContext.Preselecciones join asg in ApplicationDbContext.Asignaturas on ps.AsignaturaId equals asg.Id
                //                   select new List<string>
                //                   {
                //                       asg.NombreAsig
                //                   };
                model = ApplicationDbContext.Asignaturas.ToList();
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult myPreselection()
        {
            Estudiante Estudiante = new Estudiante();
            var user = UserManager.FindById(User.Identity.GetUserId());
            var PreSel = new List<PreSeleccion>();
            var Dbcontext = new ApplicationDbContext();
                Estudiante = Dbcontext.Estudiantes.Where(a => a.ApplicationUser.Id.Equals(user.Id)).FirstOrDefault();
                var Pre = from a in Dbcontext.Preselecciones join asg in Dbcontext.Asignaturas on a.AsignaturaId equals asg.Id
                          select new VMPreseleccion
                          {
                              VmPreId=a.Id,
                              codigo=asg.Codigo,
                              Name=asg.NombreAsig,
                              Tanda=a.Tanda
                          };
            Pre.ToList();
            return PartialView(Pre);
        }

        [HttpPost]
        public ActionResult myPreselection(VMPreseleccion Preseleccion, int id)
        {
            Estudiante Estudiante = new Estudiante();
            var user = UserManager.FindById(User.Identity.GetUserId());
            using (var Db = new ApplicationDbContext())
            {
                Estudiante = Db.Estudiantes.Where(a => a.ApplicationUser.Id.Equals(user.Id)).FirstOrDefault();
                var PreSel = Db.Preselecciones.Where(x=>x.EstudianteId==Estudiante.Id && x.Id== id).FirstOrDefault();
                
                Db.Preselecciones.Remove(PreSel);
                Db.SaveChanges();
            }
           return View("Pre_Seleccion");
        }


        public ActionResult ShowPensum()
        {
            return View(ApplicationDbContext.Asignaturas.ToList());
        }

        #region Uselless

        // GET: Estudiante/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
      #endregion
    }

}
