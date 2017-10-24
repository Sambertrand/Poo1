
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    public class DRH : Directeur
    {
        public DRH(string firstname, string lastname) : base(firstname, lastname)
        {

        }

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
