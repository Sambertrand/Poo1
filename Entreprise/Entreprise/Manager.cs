
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    public class Manager : Employee
    {

        private List<Consultant> bossOf = new List<Consultant>();
        private double baseSalary = 60000;
        private Dictionary<int, double> salaries = new Dictionary<int, double>();
        private string matricule;

        public Manager(string firstname, string lastname, string matricule) : base(firstname, lastname)
        {
            this.matricule = matricule;
        }

        /// <summary>
        /// internal method used to add consultant to the managers list
        /// </summary>
        /// <param name="consultant"></param>
        public void AddConsultant(Consultant consultant)
        {
            bossOf.Add(consultant);
        }

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

        public List<Consultant> GetSubs
        {
            get { return bossOf; }
        }

        public string Matricule
        {
            get { return matricule; }
        }

        public double GetYearSalary(int year)
        {
            UpdateSalary(year);
            return salaries[year];
        }

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
