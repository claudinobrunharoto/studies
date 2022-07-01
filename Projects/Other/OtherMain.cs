using System.Text;
using Generics.Entities; // pra usar o Product

namespace Course
{
    class OtherMain
    {
        public OtherMain()
        {
            Console.WriteLine("Outros testes:\n");
            Console.WriteLine("1 - Files");
            Console.WriteLine("2 - Lambda");
            string userOption = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            if (userOption == "1") {
                Files();
            } else {
                Lambda();
            }
        }
        private void Files()
        {
            Console.WriteLine("Trabalhando com arquivos!");
            string sourcePath = "/home/claudino/Documents/";

            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Hello world!");
                sb.AppendLine("Good morning");
                sb.AppendLine("It's me! Mario!");

                File.AppendAllText(sourcePath + "Test1.txt", sb.ToString()); // criando um arquivo utilizando o "FILE" que NÃO PRECISA ser instanciado
                Console.WriteLine("Criado o arquivo " + sourcePath + "Test1.txt");

                FileInfo fi = new FileInfo(sourcePath + "Test1.txt");
                fi.CopyTo(sourcePath + "Test2.txt"); // copiando o arquivo pelo FileInfo que PRECISA ser instanciado
                Console.WriteLine("Arquivo copiado para " + sourcePath + "Test2.txt");
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);  // */
            }
        }

        private void Lambda()
        {
            Console.WriteLine("Trabalhando com Lambda!");

            List<Product> lista = new List<Product>();

            lista.Add(new Product("Tv", 900.00));
            lista.Add(new Product("Mouse", 50.00));
            lista.Add(new Product("Tablet", 350.50));
            lista.Add(new Product("HD Case", 80.90));

            Console.WriteLine("1 - Action");
            Console.WriteLine("2 - Func");
            string userOption = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            if (userOption == "1")
            {
                // o ForEach de uma lista espera como parâmetro um Action
                // Action é um delegate void (por isso usam-se as chaves)
                lista.ForEach(p => { p.Price += p.Price * 0.1; }); // aumenta o preço em 10% para todos os produtos

                foreach (Product p in lista)
                {
                    Console.WriteLine(p);
                }
            } else {
                // o Select (do Linq) espera como parâmetro um Func
                // Func é um delegate que retorna um valor
                // o Select retorna um IEnumerable (que é uma coleção mais genérica) e neste caso precisa ser transformada em outra lista... por isso o .ToList()
                List<string> resultado = lista.Select(p => p.Name.ToUpper()).ToList(); // cria uma nova lista com os produtos com nome em maiúsculo

                foreach (string s in resultado)
                {
                    Console.WriteLine(s);
                }
            }

            

            

            
        }
    }
}