﻿using LinqCwiczenia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqCwiczenia
{
    public partial class Form1 : Form
    {
        public IEnumerable<Emp> Emps { get; set; }
        public IEnumerable<Dept> Depts { get; set; }

        public Form1()
        {
            InitializeComponent();
            LoadData();

            //LINQ to SQL, EF
            //LINQ to XML
            //LINQ - Language Integrated Query - IEnumerable<T>


            //1. Extension methods
            string str = "s1234";
            if (str.IsPjatkIndex())
            {

            }

            //2. Anonymous types
            var anon = new
            {
                FirstName="Jan",
                LastName="Kowalski"
            };

            //System.Dynamic
            //dynamic d = "Ala";
            //d = 10;

            //3. Wyrażenia Lambda/Anonimowe metody
            // delegate -> function pointer
            // event
            //Action, Function
            List<int> nums2 = new List<int>() { 3, 4, 2, 3, 1, 2, 3 };
            //var res = Filter(nums2, i => {
            //    //...
            //    return i % 2 == 1;
            //});
            var res = nums2.Filter(i => i % 2 == 0);


        }

        public static bool sdialjmlmaldakmdlsamdka(int i)
        {
            return i % 2 == 1;
        }

        private void LoadData()
        {
            Depts = Dept.CreateExampleData();
            Emps = Emp.CreateExampleData();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        private void Przyklad1Button_Click(object sender, EventArgs e)
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko=emp.Ename,
                          Zawod=emp.Job
                      };


            //2. Lambda and Extension methods


            ResultsDataGridView.DataSource = res.ToList();
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        private void Przyklad2Button_Click(object sender, EventArgs e)
        {
            var res = (from emp in Emps
                       join dept in Depts on emp.Deptno equals dept.Deptno
                       where emp.Job == "Frontend programmer" && emp.Salary > 1000
                       orderby emp.Ename descending
                       select emp).ToList();

            var res2 = Emps
                        .Where((emp, indx) => emp.Job == "Frontend programmer" && emp.Salary > 1000)
                        .OrderByDescending(emp => emp.Ename)
                        //.Filter(emp => emp.Mgr==1000)
                        .Select(emp => new
                        {
                            emp.Ename,
                            emp.Salary,
                            LiczbaDept=Depts.Count()
                        });


            ResultsDataGridView.DataSource = res2.ToList();
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        private void Przyklad3Button_Click(object sender, EventArgs e)
        {
            var min = Emps.Min(emp => emp.Salary);
            var max = Emps.Max(emp => emp.Salary);
            var avg = Emps.Average(emp => emp.Salary);

            var groupBy = Emps.GroupBy(emp => emp.Deptno);

            var joinResult = Emps
                    .Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
                    {
                        emp,
                        dept
                    });

            //map, reduce, filter
            //select, aggregate, where

            var p1 = Emps.All(emp => emp.Salary > 2000);
            var p2 = Emps.Any(emp => emp.Salary > 2000);

            var p3 = Emps.Count(emp => emp.Salary > 2000);

            //var p4 = Emps.Skip(10).Take(10);

            var p5 = Emps.Distinct();

            var p6 = Emps.Sum(emp => emp.Salary);

            var p7 = Emps.First(); //EX
            var p7_2 = Emps.FirstOrDefault(); //null

            var p8 = Emps.Single();
            var p8_2 = Emps.SingleOrDefault();

            var p9 = Emps
                        .Select(emp => emp.Salary)
                        .Aggregate((res, next) => res+next);

            //Dynamic LINQ - Emps.OrderBy(zmienna)
            //PLINQ - Parallel LINQ
            //Emps.AsParallel() // ThreadPool


            int g = 0;
            //WynikTextBox.Text = result + "";
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        private void Przyklad4Button_Click(object sender, EventArgs e)
        {

            //ResultsDataGridView.DataSource = result;
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        private void Przyklad5Button_Click(object sender, EventArgs e)
        {

            //ResultsDataGridView.DataSource = result;
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        private void Przyklad6Button_Click(object sender, EventArgs e)
        {

            //ResultsDataGridView.DataSource = result;
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        private void Przyklad7Button_Click(object sender, EventArgs e)
        {

            //ResultsDataGridView.DataSource = result;
        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        private void Przyklad8Button_Click(object sender, EventArgs e)
        {
            /*
            if (LINQ)
            {
                WynikTextBox.Text = "Backend programmer istnieje w kolekcji";
            }
             */
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        private void Przyklad9Button_Click(object sender, EventArgs e)
        {

            //ResultsDataGridView.DataSource = result;
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        private void Przyklad10Button_Click(object sender, EventArgs e)
        {

            //ResultsDataGridView.DataSource = result;
        }




    }
}
