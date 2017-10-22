
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Entreprise
{
    /// <summary>
    /// This is the Clients class with get consultant missions 
    /// </summary>
    public class Client
    {

        private string name;
        private Dictionary<int, List<Mission>> missions =
            new Dictionary<int, List<Mission>>();


        public Client(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Method made to get the clients name publically
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Method that adds a mission to the clients missions list used to generate the DRH report
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

        /// <summary>
        /// accessor to the missions list of any given client
        /// </summary>
        public Dictionary<int, List<Mission>> Missions
        {
            get { return missions; }
        }
    }
}
