
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entreprise
{
    public class DF : Directeur
    {
        /**
        * 
        */
        public DF(string firstname, string lastname) : base(firstname, lastname)
        {
        }

        /**
        * @return
        */
        public void GenerateReport()
        {
            List<string> lines = new List<string>();

            /*fill the list of strings of each line every item of the list
             */
            lines.ToArray();
            System.IO.File.WriteAllLines(@"../../RapportDF.txt", lines);
        }
    }
}
