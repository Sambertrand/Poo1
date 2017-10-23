
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    /// <summary>
    /// Financial Directors Class that will genrate his report
    /// </summary>
    public class DF : Directeur
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public DF(string firstname, string lastname) : base(firstname, lastname)
        {

        }

        /// <summary>
        /// Report genrator
        /// </summary>
        /// <param name="directeurs"></param>
        /// <param name="managers"></param>
        /// <param name="year"></param>
        public void GenerateReport(List<Directeur> directeurs, List<Manager> managers, int year)
        {
            List<string> lines = new List<string>
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
                foreach(Consultant con in man.GetSubs)
                {
                    line = "----|" + con.ToString() + " : " + con.GetYearSalary(year) + " €";
                    lines.Add(line);
                }
            }

            lines.ToArray();
            System.IO.File.WriteAllLines(@"../../../RapportDF.txt", lines);
        }
    }
}
