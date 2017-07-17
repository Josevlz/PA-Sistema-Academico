using DataModels;
using Sistema_Academico.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_Academico.Repository
{
    public class _Estudiante
    {
        private readonly ApplicationDbContext _dbContext;

        public _Estudiante(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetId(string UserId)
        {
            return _dbContext.Estudiantes.Where(x => x.ApplicationUser.Id == UserId).Select(x=>x.Id).Single();
        }

        public List<Asignatura> Est_Pensum(int Id)
        {
            var Mycarrera = GetCarreraId(Id);
            var Pensum = _dbContext.Pensums.Where(x => x.Carrera.CarreraId == Mycarrera).Include(a => a.Asignatura).FirstOrDefault();
            return Pensum.Asignatura.ToList();
        }

        private int GetCarreraId(int id)
        {
            return _dbContext.Estudiantes.Where(x => x.Id == id).Select(c => c.Carrera.CarreraId).SingleOrDefault();
        }
    }
}