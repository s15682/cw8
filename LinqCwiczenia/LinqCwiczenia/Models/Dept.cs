using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCwiczenia.Models
{
    public class Dept
    {
        public int Deptno { get; set; }
        public string Dname { get; set; }
        public string Loc { get; set; }

        public Dept(int no, string name, string loc)
        {
            Deptno = no;
            Dname = name;
            Loc = loc;
        }

        public static List<Dept> CreateExampleData()
        {
            List<Dept> list = new List<Dept>();
            list.Add(new Dept(1, "Zarząd", "Warszawa"));
            list.Add(new Dept(2, "Spedycja", "Warszawa"));
            list.Add(new Dept(3, "Pomoc Drogowa", "Płock"));
            return list;
        }

    }
}
