
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

        public void generateReport()
        {
            List<string> lines = new List<string>();

            /*
             * fill the list of strings of each line every item of the list
             */
            lines.ToArray();
            System.IO.File.WriteAllLines(@"../../RapportDRH.txt", lines);
        }
    }
}
