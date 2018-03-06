using Modelos;
using System;

namespace ConsoleView
{
    class Program
    {
        //Utiliza quando as opções são FIXAS!
        enum OpcoesMenuPrincipal
        {
            CadastrarCliente = 1,
            PesquisarCliente = 2,
            EditarCliente = 3,
            ExcluirCliente = 4,
            LimparTela = 5,
            Sair = 6
        }

        private static OpcoesMenuPrincipal Menu()
        {
            
            Console.WriteLine("Escolha sua opção: ");
            Console.WriteLine("");

            Console.WriteLine("- Clientes -");
            Console.WriteLine("1 - Cadastrar Novo");
            Console.WriteLine("2 - Pesquisar Cliente");
            Console.WriteLine("3 - Editar Cliente");

            Console.WriteLine("- Geral - ");
            Console.WriteLine("4 - Limpar Tela");
            Console.WriteLine("5 - Sair");

            string opcao = Console.ReadLine();
            return (OpcoesMenuPrincipal)int.Parse(opcao);
            //return int.Parse(Console.ReadLine());
            //Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            OpcoesMenuPrincipal opcaoDigitada = OpcoesMenuPrincipal.Sair;

            do
            {
                opcaoDigitada = Menu();

                switch (opcaoDigitada)
                {
                    case OpcoesMenuPrincipal.CadastrarCliente:
                        CadastrarCliente();
                        break;
                    case OpcoesMenuPrincipal.PesquisarCliente:
                        break;
                    case OpcoesMenuPrincipal.EditarCliente:
                        break;
                    case OpcoesMenuPrincipal.ExcluirCliente:
                        break;
                    case OpcoesMenuPrincipal.LimparTela:
                        break;
                    case OpcoesMenuPrincipal.Sair:
                        break;
                    default:
                        Console.WriteLine("Opção invalida. Tente novamente");
                        break;
                }
            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);
        }

        //Métodos: Cliente
        private static Cliente CadastrarCliente()
        {
            Cliente cli = new Cliente();

            Console.Write("Digite o nome: ");
            cli.Nome = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite o CPF: ");
            cli.Cpf = Console.ReadLine();

            //Endereco
            Endereco end = new Endereco();
            Console.Write("Digite o endereco. Rua: ");
            end.Rua = Console.ReadLine();

            Console.Write("Número: ");
            end.Numero = int.Parse(Console.ReadLine());

            Console.Write("Complemento: ");
            end.Complemento = Console.ReadLine();

            cli._Endereco = end;

            Console.WriteLine("Endereco: " + cli._Endereco.Rua + ", " + cli._Endereco.Numero 
                + " - Compl:"+ cli._Endereco.Complemento);


            return cli;
            /*
             cli._Endereco = new Endereco(); //Instanciar o endereço
             cli._Endereco.Rua = ...
            */
        }

        private static Cliente PesquisarCliente()
        {
            //TODO: Fazer depois
            return new Cliente();
        }
    }
}
