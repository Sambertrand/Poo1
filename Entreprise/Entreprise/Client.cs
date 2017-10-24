
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Entreprise
{
    public class Client
    {
        private string matricule;
        private string name;
        private Dictionary<int, List<Mission>> missions =
            new Dictionary<int, List<Mission>>();


        public Client(string name, string matricule)
        {
            this.name = name;
            this.matricule = matricule;
        }

        public string Name
        {
            get { return name; }
        }

        public string Matricule
        {
            get { return matricule; }
        }

        public void AddMission(Mission mission)
        {
			int year = mission.StartDate.Year;
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

        /// <summary>
        /// accessor to the missions list of any given client
        /// </summary>
        public Dictionary<int, List<Mission>> Missions
        {
            get { return missions; }
        }
    }
}
