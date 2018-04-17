using Models;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ClienteController
    {

        public void SalvarCliente(Cliente cliente)
        {
            Contexto ctx = new Contexto();
            ctx.tblClientes.Add(cliente);
            ctx.SaveChanges();
        }
        /*
        public Cliente PesquisarPorNome(string nome)
        {
            var c = from x in MeusClientes
                    where x.Nome.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public Cliente PesquisarPorID(int idCliente)
        {
            var c = from x in MeusClientes
                    where x.PessoaID.Equals(idCliente)
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public void ExcluirCliente(int idCliente)
        {
            Cliente cli = PesquisarPorID(idCliente);
            if (cli != null)
                MeusClientes.Remove(cli);
        }

        public List<Cliente> ListarClientes()
        {
            return MeusClientes;
        }

        public void EditarCliente(int idClienteEditar, Cliente ClienteEditado)
        {
            Cliente ClienteEditar = PesquisarPorID(idClienteEditar);

            ClienteEditar.Nome = ClienteEditado.Nome;
            ClienteEditar.Cpf = ClienteEditado.Cpf;
        }
        */

    }
}
