using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModels;

namespace Sistema_Academico.Repository
{
    public class DataRepo
    {
        public List<Subject> GetSubjects()
        {
            List<Subject> MySubjects = new List<Subject>()
            {
                new Subject
                {
                    SubjectID = 1,
                    SubjectName="Programacion Avanzada",
                    Code="SIS306",
                    Credits=5
                },

                  new Subject
                {
                    SubjectID = 2,
                    SubjectName="Base de datos",
                    Code="SIS321",
                    Credits=4
                },
                    new Subject
                {
                    SubjectID = 1,
                    SubjectName="Sistema Operativo",
                    Code="SIS251",
                    Credits=5
                }
            };
                

            return MySubjects;
        }
    }
}