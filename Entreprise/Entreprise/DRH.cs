
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
            DateTime now = DateTime.Now;
            string line = null;
            string path = (@"../../../RapportDRH" + client.Name +".txt");
            List<string> lines = new List<string>
                {
                    "Liste des consultants dans " + client.Name +" :",
                    " "
                };

            if (client.Missions.ContainsKey(now.Year))
            {
                
                foreach (Mission mis in client.Missions[now.Year])
                {
                    line = mis.Consultant.ToString() + " : du " + mis.StartDate.ToString("MM/dd/yyyy") + " au " + mis.EndDate.ToString("MM/dd/yyyy");
                    lines.Add(line);
                }
            }

            else
            {
                lines.Add("Aucun");
            }

            lines.ToArray();
            System.IO.File.WriteAllLines(path, lines);

        }
    }
}
