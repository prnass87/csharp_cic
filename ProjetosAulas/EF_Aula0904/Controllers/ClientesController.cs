using EF_Aula0904.Models;
using EF_Aula0904.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Aula0904.Controllers
{
    public class ClientesController
    {
        //INSERT
        public static void SalvarCliente(Cliente cli)
        {
            MeuContexto bancoDados = new MeuContexto();

            bancoDados.tblClientes.Add(cli);
            bancoDados.SaveChanges();
        }

        //SELECT *
        public static List<Cliente> ListarTodosClientes()
        {
            MeuContexto bancoDados = new MeuContexto();
            return bancoDados.tblClientes.ToList();
        }

        //SELECT BY ID
        public static Cliente CarregarPorID(int id)
        {
            MeuContexto bancoDados = new MeuContexto();
            return bancoDados.tblClientes.Find(id);
        }


        //EDIT
        public static void EditarClientes(int id, Cliente novoCliente)
        {
            MeuContexto bancoDados = new MeuContexto();
            Cliente clienteAtual = bancoDados.tblClientes.Find(id);

            clienteAtual.Nome = novoCliente.Nome;
            clienteAtual.CPF = novoCliente.CPF;

            bancoDados.Entry(clienteAtual).State = 
                System.Data.Entity.EntityState.Modified;
            bancoDados.SaveChanges();
        }

        //Excluir
        public static void ExcluirCliente(int id)
        {
            MeuContexto bancoDados = new MeuContexto();
            Cliente clienteAtual = bancoDados.tblClientes.Find(id);

            bancoDados.Entry(clienteAtual).State =
                System.Data.Entity.EntityState.Deleted;

            bancoDados.SaveChanges();
        }
    }
}
