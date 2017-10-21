
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Entreprise
{
    public class Client
    {

        private string name;
        private Dictionary<int, List<Mission>> missions =
            new Dictionary<int, List<Mission>>();


        public Client(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
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

        public Dictionary<int, List<Mission>> Missions
        {
            get { return missions; }
        }

    }
}