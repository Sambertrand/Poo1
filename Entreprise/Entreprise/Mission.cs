
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    /// <summary>
    /// Class that will take care of the missons consultants are send on at a clients demand
    /// </summary>
    public class Mission
    {

        private Consultant consultant;
        private Client client;
        private DateTime startDate;
        private DateTime endDate;
        private int startYear;
        private int endYear;

        public Mission(Client client, Consultant consultant,
                       DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.client = client;
            this.consultant = consultant;
            startYear = startDate.Year;
            endYear = endDate.Year;
            try
            {
                consultant.AddMission(this);
                client.AddMission(this);
            }
            catch
            {
                Console.WriteLine("Error when loading the mission {0}, {1}",
                                  Client.Name, Consultant);
                Console.WriteLine(" ");
            }

        }

        public Consultant Consultant
        {
            get { return consultant; }
        }

        public Client Client
        {
            get { return client; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
        }
    }
}
