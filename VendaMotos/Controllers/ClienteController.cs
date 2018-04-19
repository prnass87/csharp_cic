using Models;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ClienteController : BaseController
    {
        
        public void SalvarCliente(Cliente cliente)
        {
            Ctx.tblClientes.Add(cliente);
            Ctx.SaveChanges();
        }

        public void ExcluirCliente(int idCliente)
        {
            Cliente cli = PesquisarPorID(idCliente);

            if (cli != null)
            {
                Ctx.Entry(cli).State = System.Data.Entity.EntityState.Deleted;
                Ctx.SaveChanges();
            } 
        }

        public void EditarCliente(int idClienteEditar, Cliente ClienteEditado)
        {
            Cliente ClienteEditar = PesquisarPorID(idClienteEditar);

            ClienteEditar.Nome = ClienteEditado.Nome;
            ClienteEditar.Cpf = ClienteEditado.Cpf;
            ClienteEditar._Endereco.Rua = ClienteEditado._Endereco.Rua;
            ClienteEditar._Endereco.Complemento = ClienteEditado._Endereco.Complemento;
            ClienteEditar._Endereco.Numero = ClienteEditado._Endereco.Numero;

            Ctx.Entry(ClienteEditar).State = System.Data.Entity.EntityState.Modified;
            Ctx.SaveChanges();
        }

        public Cliente PesquisarPorNome(string nome)
        {
            var cli = (from c in Ctx.tblClientes
                           where c.Nome.Contains(nome)
                           select c).First();

            if (cli != null)
                return cli;
            else
                return null;
        }

        public Cliente PesquisarPorID(int idCliente)
        {
            var cli = from x in Ctx.tblClientes
                    where x.PessoaID.Equals(idCliente)
                    select x;

            if (cli != null)
                return cli.FirstOrDefault();
            else
                return null;
        }

    }
}
