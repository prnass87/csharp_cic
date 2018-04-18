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

        public void ExcluirCliente(int idCliente)
        {
            Contexto ctx = new Contexto();
            Cliente cli = PesquisarPorID(idCliente);

            if (cli != null)
            {
                ctx.Entry(cli).State = System.Data.Entity.EntityState.Deleted;
                //ctx.tblClientes.Remove(cli);
                ctx.SaveChanges();
            } 
        }

        public Cliente PesquisarPorNome(string nome)
        {
            Contexto ctx = new Contexto();

            var cli = (from c in ctx.tblClientes
                           where c.Nome.Contains(nome)
                           select c).First();

            if (cli != null)
                return cli;
            else
                return null;
        }

        public Cliente PesquisarPorID(int idCliente)
        {
            Contexto ctx = new Contexto();
            var cli = from x in ctx.tblClientes
                    where x.PessoaID.Equals(idCliente)
                    select x;

            if (cli != null)
                return cli.FirstOrDefault();
            else
                return null;
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
