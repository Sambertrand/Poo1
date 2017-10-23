
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    /// <summary>
    /// Human Resources Directors Class that will genrate his report
    /// </summary>
    public class DRH : Directeur
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public DRH(string firstname, string lastname) : base(firstname, lastname)
        {

        }

        /// <summary>
        /// Report generator for any given client
        /// </summary>
        /// <param name="client"></param>
        public void GenerateReport(Client client)
        {
            List<string> lines = new List<string>
            {
                "Liste des consultants dans " + client.Name +" :",
                " "
            };

            string line = null;
            DateTime now = DateTime.Now;

            foreach (Mission mis in client.Missions[now.Year])
            {
                line = mis.Consultant.ToString() + " : du " + mis.StartDate.ToString("MM/dd/yyyy") + " au " + mis.EndDate.ToString("MM/dd/yyyy");
                lines.Add(line);
            }
            
            lines.ToArray();
            System.IO.File.WriteAllLines(@"../../../RapportDRH.txt", lines);
        }
    }
}
