using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Entreprise
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Load from the input files
             */
            //READ DIRCTOR
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
            string patternDI = @"^D[IFH] \w+ \w+$";
            Regex rgxDI = new Regex(patternDI);
            foreach (string line in lines)
            {
                if (rgxDI.IsMatch(line))
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
            }

            //READ MANAGERS
            
            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputMan.txt");

            }
            catch
            {
                Console.WriteLine("Error of loading managers");
            }

            string patternMA = @"^\w+ \w+ MA\d+$";
            Regex rgxMA = new Regex(patternMA);
            
            foreach (string line in lines)
            {
                if (rgxMA.IsMatch(line))
                {
                    string[] words = line.Split(' ');
                    Manager manager = new Manager(words[0], words[1], words[2]);
                    ma.Add(manager);
                }
            }
            
            //READ CLIENTS
            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputCli.txt");
            }
            catch
            {
                Console.WriteLine("Error of loading clients");
            }

            string patternCI = @"^\w+ CL\d+$";
            Regex rgxCI = new Regex(patternCI);

            foreach (string line in lines)
            {
                if (rgxCI.IsMatch(line))
                {
                    string[] words = line.Split(' ');
                    Client client = new Client(words[0], words[1]);
                    ci.Add(client);
                }
                else
                {
                    Console.WriteLine("merde");
                }

            }

            //READ CONSULTANTS
            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputCon.txt");
            }
            catch
            {
                Console.WriteLine("Error of loading consultants");
            }

            string patternCO = @"^\w+ \w+ MA\d+ \d{2}(?:\d{2}) CO($1)\d+$";
            Regex rgxCO = new Regex(patternCO);

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                Manager manager = null;
                //if (rgxCO.IsMatch(line))
                //{
                    foreach (Manager man in ma)
                    {

                        if (man.Matricule == words[2])
                        {
                            manager = man;
                        }

                    }
               //}
                Consultant consultant = new Consultant(words[0], words[1], manager, Int32.Parse(words[3]), words[4], ci[0]);
            }

            
            //READ MISSION
            try
            {
                lines = System.IO.File.ReadAllLines(@"../../../inputMis.txt");
            }

            catch
            {
                Console.WriteLine("Error of loading missions");
            }

            //string patternMI = @"^CL\d+ CO\d{2}\d+ (((31-((0[13578])|(1[02])))|([012]\d)-((0\d)|(1[012]))|(30-((0[13456789])|1[012])))-\d{4}) (((31-((0[13578])|(1[02])))|([012]\d)-((0\d)|(1[012]))|(30-((0[13456789])|1[012])))-\d{4})$";
            //Regex rgxMI = new Regex(patternMI);

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
                try
                {
                    new Mission(ci[0], consultant, consultant.GetMissions(DateIn.Year).Last().EndDate.AddDays(1), DateIn.AddDays(-1));
                }
                catch (KeyNotFoundException)
                {
                    //no mission in the consultant yet
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
                        new Mission(client, consultant, DateInbis.AddYears((c-1)), DateOutbis.AddYears(c));
                    }
                    new Mission(client, consultant, DateInbis.AddYears(c), DateOut);
                }
            }
            
           // ##Display the elements of the variables created
           
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
                        Console.Write(mis.EndDate.Year + "----|");
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
