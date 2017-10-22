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
            List<Manager> ma = new List<Manager>();
            DF difin = null;
            DRH direhu = null;
            string[] lines = System.IO.File.ReadAllLines(@"../../../inputDir.txt");
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

            lines = System.IO.File.ReadAllLines(@"../../../inputMan.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                Manager manager = new Manager(words[0], words[1], words[2]);
                ma.Add(manager);
            }
        }
    }

    
}

