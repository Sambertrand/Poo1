
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    public class DF : Directeur
    {
        public DF(string firstname, string lastname) : base(firstname, lastname)
        {

        }

        public void GenerateReport(List<Directeur> directeurs, List<Manager> managers, int year)
        {
            string path = @"../../../RapportDF" + year + ".txt";
            List <string> lines = new List<string>
            {
                "Listing des employés et leurs salaires",
                " ",
                "Directeurs :",
                " "
            };
            string line = null;

            foreach (Directeur dir in directeurs)
            {
                line = dir.ToString() + " : " + dir.GetSalary + " €";
                lines.Add(line);
            }

            lines.Add(" ");
            lines.Add("Managers et leurs consultants:");
            lines.Add(" ");

            foreach (Manager man in managers)
            {
                line = man.ToString() + " : " + man.GetYearSalary(year) + " €";
                lines.Add(line);
                foreach (Consultant con in man.GetSubs)
                {
                    if (con.YearIn <= year)
                    {
                        line = "----|" + con.ToString() + " : " + con.GetYearSalary(year) + " €";
                        lines.Add(line);
                    }
                }
            }

            lines.ToArray();
            System.IO.File.WriteAllLines(path, lines);
        }
    }
}
