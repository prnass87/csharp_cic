using System;
namespace Aula1_2802
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa p = new Pessoa();

            Console.Write("Digite seu nome: ");
            p.Nome = Console.ReadLine();
            Console.WriteLine("Olá " + p.Nome + ". Boa Aula!");
            
            Console.ReadKey();
            
        }
    }
}
