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
            List<Client> ci = new List<Client>();
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

            lines = System.IO.File.ReadAllLines(@"../../../inputCon.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                Manager manager = null;
                foreach (Manager man in ma)
                {
                    if (man.Matricule == words[2])
                    {
                        manager = man;
                    }
                }
                Consultant consultant = new Consultant(words[0], words[1], manager, Int32.Parse(words[3]), words[4]);
            }

            lines = System.IO.File.ReadAllLines(@"../../../inputCli.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                Client client = new Client(words[0], words[1]);
                ci.Add(client);
            }

            lines = System.IO.File.ReadAllLines(@"../../../inputMis.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                string[] datein = words[2].Split('-');
                string[] dateout = words[3].Split('-');
                DateTime DateIn = new DateTime(Int32.Parse(datein[2]), Int32.Parse(datein[1]), Int32.Parse(datein[0]));
                DateTime DateOut = new DateTime(Int32.Parse(dateout[2]), Int32.Parse(dateout[1]), Int32.Parse(dateout[0]));

                Client client = null;
                Consultant consultant = null;

                foreach (Client cli in ci)
                {
                    if (cli.Matricule == words[0])
                    {
                        client = cli;
                    }
                }

                foreach (Manager man in ma)
                {
                    foreach (Consultant con in man.GetSubs)
                    {
                        if (con.Matricule == words[1])
                        {
                            consultant = con;
                        }
                    }
                }

                if (DateIn.Year == DateOut.Year)
                {
                    new Mission(client, consultant, DateIn, DateOut);
                }
                else
                {
                    DateTime DateInbis = new DateTime(DateOut.Year, 01, 01);
                    DateTime DateOutbis = new DateTime(DateIn.Year, 12, 31);

                    new Mission(client, consultant, DateIn, DateOutbis);
                    new Mission(client, consultant, DateInbis, DateOut);
                }
            }

            foreach(Directeur dir in di)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine(direhu);
            Console.WriteLine(difin);
            foreach (Manager man in ma)
            {
                Console.WriteLine(man);
                foreach (Consultant con in man.GetSubs)
                {
                    Console.Write("----|");
                    Console.WriteLine(con);
                }
            }
            foreach(Client cli in ci)
            {
                Console.WriteLine(cli.Name);
                foreach (Mission mis in cli.Missions[2016])
                {
                    Console.Write("----|");
                    Console.WriteLine(mis.Consultant);
                }
                foreach (Mission mis in cli.Missions[2017])
                {
                    Console.Write("----|");
                    Console.WriteLine(mis.Consultant);
                }
            }

            ma[0].GenerateReport();
            direhu.GenerateReport(ci[0]);

            Console.ReadKey();
        }
    }
}

