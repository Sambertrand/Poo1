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
            /**
             * Load from the input files
             */
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
                    di.Add(difin);
                }

                if (words[0] == "DH")
                {
                    direhu = new DRH(words[1], words[2]);
                    di.Add(direhu);
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

            /* ##Display the elements of the var creadted
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
            difin.GenerateReport(di, ma, 2016);
            difin.GenerateReport(di, ma, 2017);

            Console.ReadKey();

            */

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select a mod (enter the number of your selection)");
                Console.WriteLine(" ");
                Console.WriteLine("1. Get report of a manager");
                Console.WriteLine("2. Get report of the Human Resources Director");
                Console.WriteLine("3. Get report of the financial director");
                Console.WriteLine(" ");
                string select = Console.ReadLine();

                if (select == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Select a manager");
                    Console.WriteLine(" ");

                    int count = 0;
                    foreach (Manager man in ma)
                    {
                        count++;
                        Console.WriteLine(count.ToString() + ". " + man.ToString());
                    }
                    bool cond = true;
                    while (cond)
                    {
                        try
                        {
                            Console.WriteLine(" ");
                            select = Console.ReadLine();
                            ma[Int32.Parse(select) - 1].GenerateReport();
                            Console.WriteLine(" ");
                            Console.WriteLine("Report generated");
                            Console.ReadKey();
                            cond = false;
                        }
                        catch
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Please select a manager");
                        }
                    }
                }

                if (select == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Select a client");
                    Console.WriteLine(" ");

                    int count = 0;
                    foreach (Client cli in ci)
                    {
                        count++;
                        Console.WriteLine(count.ToString() + ". " + cli.Name;
                    }
                    bool cond = true;
                    while (cond)
                    {
                        try
                        {
                            Console.WriteLine(" ");
                            select = Console.ReadLine();
                            difin.GenerateReport(ci[Int32.Parse(select) - 1]);
                            Console.WriteLine(" ");
                            Console.WriteLine("Report generated");
                            Console.ReadKey();
                            cond = false;
                        }
                        catch
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Please select a client");
                        }
                    }
                }

                if (select == "3")
                {

                }
            }

            
        }
    }
}
