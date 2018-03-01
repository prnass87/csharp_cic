using System;
namespace Aula1_2802
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome = string.Empty;

            Console.Write("Digite seu nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Olá, " + nome + ". Boa Aula!");
            
            Console.ReadKey();
            
        }
    }
}
