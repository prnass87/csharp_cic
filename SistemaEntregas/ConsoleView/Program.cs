using Controllers;
using Modelos;
using System;
using System.Collections.Generic;

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
            ListarClientesCadastrados = 3,
            EditarCliente = 4,
            ExcluirCliente = 5,
            LimparTela = 6,
            Sair = 7
        }

        private static OpcoesMenuPrincipal Menu()
        {

            Console.WriteLine("Escolha sua opcao");
            Console.WriteLine("");

            Console.WriteLine(" - Clientes - ");
            Console.WriteLine("1 - Cadastrar Novo");
            Console.WriteLine("2 - Pesquisar Cliente");
            Console.WriteLine("3 - Listar Clientes Cadastrados");
            Console.WriteLine("4 - Editar Cliente");
            Console.WriteLine("5 - Excluir Cliente");

            Console.WriteLine(" - Geral -");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("7 - Sair");

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
                    case OpcoesMenuPrincipal.ListarClientesCadastrados:
                        ListarTodosClientes();
                        break;
                    case OpcoesMenuPrincipal.EditarCliente:
                        break;
                    case OpcoesMenuPrincipal.ExcluirCliente:
                        ExcluirCliente();
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
        //_____________________________________________
        //Métodos: Cliente
        //_____________________________________________
        private static void ExcluirCliente()
        {
            Console.WriteLine("Digite o id do cliente que deseja excluir: ");
            int idCliente = int.Parse(Console.ReadLine());

            ClienteController cc = new ClienteController();
            cc.ExcluirCliente(idCliente);
        }
                
        private static Cliente CadastrarCliente()
        {
            Cliente cli = new Cliente();

            Console.Write("Digite o nome: ");
            cli.Nome = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite o CPF: ");
            cli.Cpf = Console.ReadLine();

            Endereco end = CadastrarEndereco();

            cli.EnderecoID = end.EnderecoID;

            return cli;
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

            ExibirDadosDeEndereco(cliente.EnderecoID);
        }

        private static void ListarTodosClientes()
        {
            Console.WriteLine();
            Console.WriteLine(" --- Clientes Cadastrados --- ");

            ClienteController cc = new ClienteController();
            List<Cliente> lista = cc.ListarClientes();

            foreach (Cliente cli in lista)
            {
                ExibirDadosCliente(cli);
            }

            Console.WriteLine();
        }

        //_____________________________________________
        //Métodos: Endereco
        //_____________________________________________

        private static Endereco CadastrarEndereco()
        {
            // ... Endereco
            Endereco end = new Endereco();

            Console.Write("Digite o nome da rua: ");
            end.Rua = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite o numero: ");
            end.Numero = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o complemento: ");
            end.Complemento = Console.ReadLine();

            EnderecoController ec = new EnderecoController();
            ec.SalvarEndereco(end);
            return end;

        }

        private static void ExibirDadosDeEndereco(int ID)
        {
            EnderecoController ec = new EnderecoController();
            Endereco e = ec.PesquisarPorId(ID);

            Console.WriteLine("- Endereco -");
            Console.WriteLine("Rua: " + e.Rua);
            Console.WriteLine("Num: " + e.Numero);
            Console.WriteLine("Compl.: " + e.Complemento);
            Console.WriteLine("-------------- ");
            Console.WriteLine();

        }
    }
}
