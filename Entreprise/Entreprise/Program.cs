using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Entreprise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Directeur> di = new List<Directeur>();
            DF difin;
            DRH direhu;
            string[] lines = System.IO.File.ReadAllLines(@"../inpput.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');

                if (words[0] == "DI")
                {
                    Directeur directeur = new Directeur(words[1], words[2]);
                    di.Add(directeur);
                }

                if (words[0] == "DF")
                {
                    difin = new DF(words[1], words[2]);
                }

                if (words[0] == "DH")
                {
                    direhu = new DRH(words[1], words[2]);
                }
            }
        }
    }

    
}
