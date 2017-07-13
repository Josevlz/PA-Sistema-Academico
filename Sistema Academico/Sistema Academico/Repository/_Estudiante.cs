using Sistema_Academico.Models;
using System;
using System.Collections.Generic;
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
    }
}