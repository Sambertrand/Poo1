
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    public class Consultant : Employee
    {

        private Manager subOf;
        private double baseSalary = 60000;
        private Dictionary<int, double> salaries = new Dictionary<int, double>();
        private Dictionary<int, List<Mission>> missions =
            new Dictionary<int, List<Mission>>();
        private int yearIn;

        public Consultant(string name, Manager subOf, int yearIn) : base(name)
        {
            this.yearIn = yearIn;
            this.subOf = subOf;
            subOf.AddConsultant(this);
        }

        private void updateSalaries(int year)
        {
            int dayEntreprise = 0;
            double bosssalary = subOf.GetYearSalary(year);
            foreach (Mission m in missions[year])
            {
                if (m.Client.Name == "Entreprise")
                {
                    TimeSpan ts = m.endDate - m.starDate;
                    dayEntreprise += ts.Day;
                }
            }

            double salaire = baseSalary - 10 * dayEntreprise + bosssalary / 100;
            salaries.add(year, salaire);
        }

        public double GetYearSalary(int year)
        {
            UpdateSalaries(year);
            return salaries[year];
        }

        public void addMission(int year, Mission mission)
        {
            try
            {
                test[year].Add(mission);

            }
            catch (KeyNotFoundException)
            {
                List<int> list = new List<int>();
                test.Add(year, list);
                test[year].Add(mission);
            }
        }

        public int YearIn
        {
            get { return yearIn; }
        }

    }
}
