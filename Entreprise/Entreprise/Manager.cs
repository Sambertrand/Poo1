
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{


    /// <summary>
    /// Manager class subclass of employee and is boss of consultants
    /// </summary>
    public class Manager : Employee
    {

        private List<Consultant> bossOf = new List<Consultant>();
        private double baseSalary = 60000;
        private Dictionary<int, double> salaries = new Dictionary<int, double>();
        private string matricule;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="matricule"></param>
        public Manager(string firstname, string lastname, string matricule) : base(firstname, lastname)
        {
            this.matricule = matricule;
        }

        /// <summary>
        /// internal method used to add consultant in the list of consultant the manager is a boss of
        /// </summary>
        /// <param name="consultant"></param>
        public void AddConsultant(Consultant consultant)
        {
            bossOf.Add(consultant);
        }

        /// <summary>
        /// updates the salary depending on a year
        /// </summary>
        /// <param name="year"></param>
        private void UpdateSalary(int year)
        {
            int count = 0;
            foreach (Consultant c in bossOf)
            {
                if (c.YearIn <= year)
                {
                    count++;
                }
            }
            salaries[year] = baseSalary + (500 * count);
        }

        /// <summary>
        /// Method that generates a list of consultants for the report
        /// </summary>
        public List<Consultant> GetSubs
        {
            get { return bossOf; }
        }

        public string Matricule
        {
            get { return matricule; }
        }

        /// <summary>
        /// method that return the salary of a given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public double GetYearSalary(int year)
        {
            UpdateSalary(year);
            return salaries[year];
        }

        /// <summary>
        /// generates the report as text document
        /// </summary>
        public void GenerateReport()
        {
            List<string> lines = new List<string>
            {
                "Liste des consultants travaillant sous " + ToString(),
                " "
            };

            string line = null;

            DateTime now = DateTime.Now;
            foreach (Consultant sub in bossOf)
            {
                foreach(Mission mis in sub.GetMissions(now.Year))
                {
                    if (mis.EndDate > now)
                    {
                        line = sub.ToString() + " : " + " jusqu'au " + mis.EndDate.ToString("MM/dd/yyyy");
                        lines.Add(line);
                    }
                }
            }

            lines.ToArray();
            System.IO.File.WriteAllLines(@"../../../RapportManager" + matricule +".txt", lines);
        }
    }
}
