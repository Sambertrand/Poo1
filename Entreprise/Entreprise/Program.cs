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
            List<Client> ci = new List<Client> {new Client("Entreprise", "CL00")};
            DF difin = null;
            DRH direhu = null;
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputDir.txt");
            }
            catch
            {
                Console.WriteLine("Error of loading directors");
            }
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

            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputMan.txt");

            }
            catch
            {
                Console.WriteLine("Error of loading managers");
            }

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                Manager manager = new Manager(words[0], words[1], words[2]);
                ma.Add(manager);
            }

            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputCli.txt");
            }
            catch
            {
                Console.WriteLine("Error of loading clients");
            }

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                Client client = new Client(words[0], words[1]);
                ci.Add(client);
            }

            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputCon.txt");
            }
            catch
            {
                Console.WriteLine("Error of loading consultants");
            }

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
                Consultant consultant = new Consultant(words[0], words[1], manager, Int32.Parse(words[3]), words[4], ci[0]);
            }

            
            
            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputMis.txt");
            }

            catch
            {
                Console.WriteLine("Error of loading missions");
            }
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
                    DateTime DateOutbis = new DateTime(DateIn.Year, 12, 31);
                    new Mission(client, consultant, DateIn, DateOutbis);
                    DateTime DateInbis = new DateTime(DateOutbis.AddYears(1).Year, 01, 01);
                    int c = 0;
                    while (DateInbis.AddYears(c).Year < DateOut.Year)
                    {
                        c++;
                        DateOutbis.AddYears(c);
                        new Mission(client, consultant, DateInbis, DateOutbis);
                        DateInbis.AddYears(c);
                        Console.WriteLine(DateInbis);
                    }
                    new Mission(client, consultant, DateInbis, DateOut);
                }
            }
            
           // ##Display the elements of the var created
           
            Console.ReadKey();
            Console.Clear();
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
                foreach (List<Mission> miss in cli.Missions.Values)
                {
                    foreach(Mission mis in miss)
                    {
                        Console.Write("----|");
                        Console.WriteLine(mis.Consultant);
                    }
                }
            }

            Console.ReadKey();
            
            //UI
            bool S = true;

            while (S)
            {
                Console.Clear();
                Console.WriteLine("Select a mod (enter the number of your selection)");
                Console.WriteLine(" ");
                Console.WriteLine("1. Get report of a manager");
                Console.WriteLine("2. Get report of the Human Resources Director");
                Console.WriteLine("3. Get report of the financial director");
                Console.WriteLine(" ");
                Console.WriteLine("enter q to quit");
				Console.WriteLine(" ");
				string sel = Console.ReadLine();

                if (sel == "1")
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
                    bool M = true;
                    while (M)
                    {
                        try
                        {
                            Console.WriteLine(" ");
                            sel = Console.ReadLine();
                            ma[Int32.Parse(sel) - 1].GenerateReport();
                            Console.WriteLine(" ");
                            Console.WriteLine("Report generated");
                            Console.ReadKey();
                            M = false;
                        }
                        catch
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Please select a manager");
                        }
                    }
                    sel = null;
                }

                if (sel == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Select a client");
                    Console.WriteLine(" ");

                    int count = 0;
                    foreach (Client cli in ci)
                    {
                        count++;
                        Console.WriteLine(count.ToString() + ". " + cli.Name);
                    }
                    bool F = true;
                    while (F)
                    {
                        try
                        {
                            Console.WriteLine(" ");
                            sel = Console.ReadLine();
                            direhu.GenerateReport(ci[Int32.Parse(sel) - 1]);
                            Console.WriteLine(" ");
                            Console.WriteLine("Report generated");
                            Console.ReadKey();
                            F = false;
                        }
                        catch
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Please select a client");
                        }
                    }
                    sel = null;
                }

                if (sel == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Enter a year completed");
                    Console.WriteLine(" ");
					bool H = true;
                    while (H)
                    {
                        try
                        {
                            sel = Console.ReadLine();
                            if (Int32.Parse(sel) != DateTime.Now.Year)
                            {
                                difin.GenerateReport(di, ma, Int32.Parse(sel));
								Console.WriteLine(" ");
								Console.WriteLine("Report generated");
								Console.ReadKey();
                                H = false;
                            }
                            else
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Please enter a year completed");
                                Console.WriteLine(" ");
                            }
                        }
                        catch
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Please enter a year completed");
                            Console.WriteLine(" ");
                        }
                    }
                    sel = null;
                }
               
                if (sel == "q" || sel == "Q")
                {
                    S = false;
                }
            }
        }
    }
}
