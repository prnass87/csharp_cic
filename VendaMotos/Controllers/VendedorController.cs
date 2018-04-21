using Models;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
     public class VendedorController : BaseController
    {
        

        public void SalvarVendedor(Vendedor vendedor)
        {
            Ctx.tblVendedores.Add(vendedor);
            Ctx.SaveChanges();

        }

        public void ExcluirVendedor(int idVendedor)
        {
            Vendedor ven = PesquisarPorID(idVendedor);

            if (ven != null)
            {
                Ctx.Entry(ven).State = System.Data.Entity.EntityState.Deleted;
                Ctx.SaveChanges();
            }
        }

        public void EditarVendedor(int idVendedorEditar, Vendedor VendedorEditado)
        {
            Vendedor VendedorEditar = PesquisarPorID(idVendedorEditar);

            VendedorEditar.Nome = VendedorEditado.Nome;
            VendedorEditar.Cpf = VendedorEditado.Cpf;
            VendedorEditar._Endereco.Rua = VendedorEditado._Endereco.Rua;
            VendedorEditar._Endereco.Complemento = VendedorEditado._Endereco.Complemento;
            VendedorEditar._Endereco.Numero = VendedorEditado._Endereco.Numero;

            Ctx.Entry(VendedorEditar).State = System.Data.Entity.EntityState.Modified;
            Ctx.SaveChanges();
        }

        public Vendedor PesquisarPorNome(string nome)
        {
            var ven = (from v in Ctx.tblVendedores
                       where v.Nome.Contains(nome)
                       select v).First();

            if (ven != null)
                return ven;
            else
                return null;
        }

        public Vendedor PesquisarPorID(int idVendedor)
        {
            var ven = from x in Ctx.tblVendedores
                      where x.PessoaID.Equals(idVendedor)
                      select x;

            if (ven != null)
                return ven.FirstOrDefault();
            else
                return null;
        }
    }
}
