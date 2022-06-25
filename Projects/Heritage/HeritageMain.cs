using Heritage.Entities;
using System.Globalization;

namespace Course
{
    class HeritageMain
    {
        public HeritageMain()
        {
            Run();
        }
        public void Run()
        {
            int n;
            List<Employee> list = new List<Employee>();

            Console.Write("Automatic mode (y/n)? ");            
            char ch = char.Parse(Console.ReadLine());
            Console.Clear();

            if (char.ToUpper(ch) == 'Y')
            {
                n = 3;
                Console.WriteLine("*** AUTOMATIC MODE ***");
                Console.WriteLine($"{n} employees added!");
                Console.WriteLine("*** AUTOMATIC MODE ***");

                list.Add(new Employee("Alex", 50, 20.00));
                list.Add(new OutsourceEmployee("Bob", 100, 15.00, 200.00));
                list.Add(new Employee("Maria", 60, 20.00));
            } else {                
                Console.Write("Enter the numer of employees: ");
                n = int.Parse(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"Employee #{1} data:");
                    Console.Write("Outsourced (y/n)? ");
                    ch = char.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Hours: ");
                    int hours = int.Parse(Console.ReadLine());
                    Console.Write("Value per hour: ");
                    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    if (char.ToUpper(ch) == 'Y')
                    {
                        Console.Write("Additional charge: ");
                        double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        list.Add(new OutsourceEmployee(name, hours, valuePerHour, additionalCharge));
                    } else {
                        list.Add(new Employee(name, hours, valuePerHour));
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("PAYMENTS:");
            foreach (Employee emp in list)
            {
                Console.WriteLine(emp.ToString());
            }
        }
    }
}