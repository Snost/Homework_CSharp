using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_Linq
{
    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }

        public Firm(string name, DateTime foundationDate, string businessProfile, string directorFullName, int employeeCount, string address)
        {
            Name = name;
            FoundationDate = foundationDate;
            BusinessProfile = businessProfile;
            DirectorFullName = directorFullName;
            EmployeeCount = employeeCount;
            Address = address;
        }
    }
    public class Program
    {
        public static void Main()
        {
            var firms = new List<Firm>
            {
                new Firm("Optimus", new DateTime(2018, 1, 17), "IT", "Andry White", 150, "25 Carnaby Street, London"),
                new Firm("iFood", new DateTime(2015, 5, 5), "Food", "White Black", 80, "45 Cardu Street, Manchester"),
                new Firm("Markett", new DateTime(2021, 3, 10), "Marketing", "Tom White", 200, "87 Darym Street, London"),
                new Firm("Cute Food", new DateTime(2024, 1, 1), "Food", "Jim Black", 50, "65 Kodert Street, London"),
                new Firm("ITGo", new DateTime(2020, 10, 10), "IT", "Sam White", 300, "31 Karpenka Street, Ternopil"),
                new Firm("Black and White", new DateTime(2020, 2, 17), "Beauty", "Anna Black", 150, "65 Nuar Street, Paris"),
                new Firm("Oster", new DateTime(2016, 5, 30), "Food", "Jenny Bare", 80, "76 Yunosti Street, Ternopil"),
                new Firm("Hype", new DateTime(2013, 7, 31), "Beaty", "Kany Ters", 200, "86 Fourtaw, Krakow")
            };

            int choice;
            bool exit = false;

            do
            {
                Console.WriteLine("Choose a query: ");
                Console.WriteLine("1. Get information about all firms.");
                Console.WriteLine("2. Get firms that have 'Food' in their name.");
                Console.WriteLine("3. Get firms that work in the field of marketing.");
                Console.WriteLine("4. Get firms that work in marketing or IT.");
                Console.WriteLine("5. Get firms with more than 100 employees.");
                Console.WriteLine("6. Get firms with employees between 100 and 300.");
                Console.WriteLine("7. Get firms located in London.");
                Console.WriteLine("8. Get firms where the director's surname is White.");
                Console.WriteLine("9. Get firms founded more than two years ago.");
                Console.WriteLine("10. Get firms founded 123 days ago.");
                Console.WriteLine("11. Get firms where the director's surname is Black and have 'White' in their name.");
                Console.WriteLine("12. Exit");

                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            var allFirms = firms.Select(x=> x);
                            PrintFirms(allFirms);
                            break;
                        case 2:
                            var nameFood = firms.Where(x => x.Name.Contains("Food"));
                            PrintFirms(nameFood);
                            break;
                        case 3:
                            var marketFirm = firms.Where(x => x.BusinessProfile == "Marketing");
                            PrintFirms(marketFirm);
                            break;
                        case 4:
                            var itOrMarket = firms.Where(x => x.BusinessProfile == "Marketing" || x.BusinessProfile == "IT");
                            PrintFirms(itOrMarket);
                            break;
                        case 5:
                            var more100Empl = firms.Where(x => x.EmployeeCount > 100);
                            PrintFirms(more100Empl);
                            break;
                        case 6:
                            var from100to300Empl = firms.Where(x => x.EmployeeCount >= 100 && x.EmployeeCount <= 300);
                            PrintFirms(from100to300Empl);
                            break;
                        case 7:
                            var londonFirm = firms.Where(x => x.Address.Contains("London"));
                            PrintFirms(londonFirm);
                            break;
                        case 8:
                            var directorWhite = firms.Where(x => x.DirectorFullName.Split(' ').Last() == "White");
                            PrintFirms(directorWhite);
                            break;
                        case 9:
                            var twoYearsAgo = DateTime.Now.AddYears(-2);
                            var more2Years = firms.Where(x => x.FoundationDate <= twoYearsAgo);
                            PrintFirms(more2Years);
                            break;
                        case 10:
                            var daysAgo123 = DateTime.Now.AddDays(-123).Date;
                            Console.WriteLine($"Looking for firms founded on: {daysAgo123.ToShortDateString()}");
                            var found123DaysAgo = firms.Where(x => x.FoundationDate.Date == daysAgo123);
                            PrintFirms(found123DaysAgo);
                            break;
                        case 11:
                            var blackWhite = firms.Where(x => x.DirectorFullName.Split(' ').Last() == "Black" && x.Name.Contains("White"));
                            PrintFirms(blackWhite);
                            break;
                        case 12:
                            Console.WriteLine("Exiting...");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 12");
                }

                if (!exit)
                {
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (!exit);
        }

        public static void PrintFirms(IEnumerable<Firm> firms)
        {
            if (!firms.Any())
            {
                Console.WriteLine("No firms found");
            }
            foreach (var firm in firms)
            {
                Console.WriteLine($"{firm.Name}\n Foundation Date: {firm.FoundationDate.ToShortDateString()}\n Profile: {firm.BusinessProfile}\n Director: {firm.DirectorFullName}\n Employees: {firm.EmployeeCount}\n Address: {firm.Address}\n");
            }
        }
    }
}
