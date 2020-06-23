using System;
using System.Collections.Generic;
using System.Text;

namespace LinqConsoleApp
{
    public class Emp
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public int? Deptno { get; set; }
        public Emp Mgr { get; set; }

        public Emp( int nr, string name, string job, int salary, DateTime? hireDate, int? deptno, Emp mgr)
        {
            Empno = nr;
            Ename = name;
            Job = job;
            Salary = salary;
            HireDate = hireDate;
            Deptno = deptno;
            Mgr = mgr; 
        }

        public override string ToString()
        {
            return Ename + " (" + Empno + ")";
        }

        public static List<Emp> CreateExampleData()
        {
            List<Emp> list = new List<Emp>();
            list.Add(new Emp(1, "Jan", "Szef", 10000, new DateTime(2000, 10, 12), 1, null));
            list.Add(new Emp(2, "Michał", "Kierowca", 2000, new DateTime(2002, 10, 12), 2, list[0]));
            list.Add(new Emp(2, "Wacław", "Kierowca", 3400, new DateTime(2005, 10, 12), 1, list[0]));
            list.Add(new Emp(2, "Łukasz", "Mechanik", 2400, new DateTime(2003, 10, 12), 2, list[0]));
            list.Add(new Emp(2, "Miłosz", "Mechanik", 1400, new DateTime(2003, 10, 12), 2, list[3]));
            list.Add(new Emp(2, "Janusz", "Mechanik", 3400, new DateTime(2003, 10, 12), 3, list[0]));

            return list; 
        }
    }
}
