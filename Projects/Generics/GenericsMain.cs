using Generics.Entities;
using Generics.Services;
using System.Globalization;

namespace Course
{
    class GenericsMain
    {
        // utilizando o CalculationService que recebe um "valor genérico" e executa cálculos conforme o tipo "T" informado
        // neste exemplo temos o tipo int e o tipo Produto (que é uma classe - precisa extender o IComparable)
        // o CalculationService consegue fazer as operações com ambos os tipos sem problemas!!!
        public GenericsMain()
        {
            Run();
        }

        private void Run()
        {
            Console.Write("Product or Number (p/n)?: ");
            string userOption = Console.ReadLine() ?? String.Empty;
            Console.WriteLine();

            if (userOption.ToUpper() == "P")
            {
                List<Product> list = new List<Product>();

                Console.Write("Enter the number of products: ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();

                for (int i = 0; i < n; i++) {
                    Console.Write("Product #" + i + 1 + " (Name,price): ");
                    string[] vect = Console.ReadLine().Split(',');
                    double price = double.Parse(vect[1], CultureInfo.InvariantCulture);
                    list.Add(new Product(vect[0], price));
                }

                CalculationService calculationService = new CalculationService();

                Product p = calculationService.Max(list); // <Product> is optional

                Console.WriteLine("Most expensive:");
                Console.WriteLine(p);
            } else {
                List<int> list = new List<int>();

                Console.Write("Enter the number of products: ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();

                for (int i = 0; i < n; i++) {
                    Console.Write("Tipe a number: ");
                    int number = int.Parse(Console.ReadLine());
                    list.Add(number);
                }

                CalculationService calculationService = new CalculationService();

                int p = calculationService.Max(list);

                Console.WriteLine("Max number:");
                Console.WriteLine(p);
            }
        }
    }
}