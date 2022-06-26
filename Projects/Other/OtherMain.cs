using System.Text;

namespace Course
{
    class OtherMain
    {
        public OtherMain()
        {
            Console.WriteLine("Outros testes:\n");
            Run();
        }
        public void Run()
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
                Console.WriteLine(e.Message);
            }
        }
    }
}