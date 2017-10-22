
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    public class Consultant : Employee
    {

        private Manager subOf;
        private double baseSalary = 35000;
        private Dictionary<int, double> salaries = new Dictionary<int, double>();
        private Dictionary<int, List<Mission>> missions =
            new Dictionary<int, List<Mission>>();
        private int yearIn;

        public Consultant(string firstname, string lastname, Manager subOf, int yearIn) : base(firstname, lastname)
        {
            this.yearIn = yearIn;
            this.subOf = subOf;
            subOf.AddConsultant(this);
        }

        private void UpdateSalaries(int year)
        {
            int dayEntreprise = 0;
            double bosssalary = subOf.GetYearSalary(year);
            foreach (Mission m in missions[year])
            {
                if (m.Client.Name == "Entreprise")
                {
                    TimeSpan ts = m.EndDate - m.StartDate;
                    dayEntreprise += ts.Days;
                }
            }

            double salaire = baseSalary - 10 * dayEntreprise + bosssalary / 100;
            salaries.Add(year, salaire);
        }

        public double GetYearSalary(int year)
        {
            try
            {
                UpdateSalaries(year);
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
            return salaries[year];
        }

        public void AddMission(int year, Mission mission)
        {
            try
            {
                missions[year].Add(mission);

            }
            catch (KeyNotFoundException)
            {
                List<Mission> list = new List<Mission>();
                missions.Add(year, list);
                missions[year].Add(mission);
            }
        }

        public int YearIn
        {
            get { return yearIn; }
        }

    }
}
