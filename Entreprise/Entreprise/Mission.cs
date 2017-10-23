
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    public class Mission
    {

        private Consultant consultant;
        private Client client;
        private DateTime startDate;
        private DateTime endDate;
        private int year;
        private int year1;

        public Mission(Client client, Consultant consultant,
                       DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.client = client;
            this.consultant = consultant;
            year = startDate.Year;
            year1 = endDate.Year;
            try
            {
                consultant.AddMission(this);
                client.AddMission(this);
            }
            catch
            {
                Console.WriteLine("Error when loading the mission {0}, {1}",
                                  Client.Name, Consultant);
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
