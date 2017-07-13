using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModels;
using Sistema_Academico.Repository;

namespace Sistema_Academico.Controllers
{
    public class HomeController : Controller
    {
        DataRepo Repo = new DataRepo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Main()
        {
            
            return View();
        }

        public ActionResult Partial()
        {
            //ViewBag.text = "Sample text";
            //Usuario MyUser = new Usuario
            //{
            //    UserID = 1057446,
            //    Name = "Jose valdez",
            //    IndiceT=4.00,
            //    IndiceG=3.5,
            //    Condition="Normal",
            //    career="Ingenieria en sistemas"
            //};
            
            return PartialView();
        }

        public ActionResult _AllSubjects()
        {
            
            return PartialView();
        }
    }
}