
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
            this.year = startDate.Year;
            this.year1 = endDate.Year;
            if (year == year1)
            {
                client.AddMission(year, this);
                consultant.AddMission(year, this);
            }
            /*else
            {
                // à faire dans le READER
                new Mission(client, consultant, DateTime(year1, 01, 01), endDate);
                new Mission(client, consultant, startDate, DateTime(year, 12, 31));

            }
            */

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