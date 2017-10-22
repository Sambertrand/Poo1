
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    /// <summary>
    /// Class that generates Employees that are consultants with missions and managers
    /// </summary>
    public class Consultant : Employee
    {

        private Manager subOf;
        private double baseSalary = 35000;
        private Dictionary<int, double> salaries = new Dictionary<int, double>();
        private Dictionary<int, List<Mission>> missions =
            new Dictionary<int, List<Mission>>();
        private int yearIn;
        private string matricule;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="subOf"></param>
        /// <param name="yearIn"></param>
        /// <param name="matricule"></param>
        public Consultant(string firstname, string lastname, Manager subOf, int yearIn, string matricule) : base(firstname, lastname)
        {
            this.matricule = matricule;
            this.yearIn = yearIn;
            this.subOf = subOf;
            subOf.AddConsultant(this);
        }

        /// <summary>
        /// Method that generates the salary of the consultant for any given year
        /// </summary>
        /// <param name="year"></param>
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

        /// <summary>
        /// Method that returns the salary of the consultant for any given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method that adds a new mission to the mission list of the consultant
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mission"></param>
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

        public string Matricule
        {
            get { return matricule; }
        }
    }
}
