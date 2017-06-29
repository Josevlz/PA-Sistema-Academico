using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{

    public class Usuario
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public double IndiceT { get; set; }
        public double IndiceG { get; set; }
        public string Condition { get; set; }
        public string career { get; set; }

    }

    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }
        
    }
}
