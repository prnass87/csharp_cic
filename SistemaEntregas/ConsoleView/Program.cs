using Controllers;
using Modelos;
using System;

//F5 - MODO NORMAL (ou até o proximo break point)
//F9 - BREAK POINT
//F10 - EXEXUTA PASSO
//F11 - ENTRA NO PASSO

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
                        //retorna um cliente na função, armazena em uma variavel "Cliente";
                        Cliente c = CadastrarCliente();
                        //Pega a variavel que possui informações e passa ela como parametro;
                        ExibirDadosCliente(c); //

                        //Instanciar o método pq não é static.
                        ClienteController cc = new ClienteController();
                        cc.SalvarCliente(c);

                        break;
                    case OpcoesMenuPrincipal.PesquisarCliente:
                        PesquisarCliente();
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
            Console.Write("Rua: ");
            end.Rua = Console.ReadLine();

            Console.Write("Número: ");
            end.Numero = int.Parse(Console.ReadLine());

            Console.Write("Complemento: ");
            end.Complemento = Console.ReadLine();

            cli._Endereco = end;

            return cli;
            /*
             cli._Endereco = new Endereco(); //Instanciar o endereço
             cli._Endereco.Rua = ...
            */
        }

        private static void PesquisarCliente()
        {
            Console.WriteLine("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            ClienteController cc = new ClienteController();
            Cliente cli = cc.PesquisarPorNome(nomeCliente);

            if (cli != null)
                ExibirDadosCliente(cli);
            else
                Console.WriteLine(" * Cliente não encontrado! ");
        }

        private static void ExibirDadosCliente(Cliente cliente)
        {
            Console.WriteLine();
            Console.WriteLine("--Dados Cliente--");
            Console.WriteLine("Cliente ID: " + cliente.PessoaID);
            Console.WriteLine("Cliente: " + cliente.Nome);
            Console.WriteLine("CPF do Cliente: " + cliente.Cpf);
            
            Console.WriteLine("--Endereço--");
            Console.WriteLine("Rua: " + cliente._Endereco.Rua + ", Num: " + cliente._Endereco.Numero + " - Compl: " + cliente._Endereco.Complemento);
            Console.WriteLine("------------------");
            Console.WriteLine();
        }
    }
}
