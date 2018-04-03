using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
     public class VendedorController
    {
        static List<Vendedor> MeusVendedores = new List<Vendedor>();
        static int ultimoID = 0;

        public void SalvarVendedor(Vendedor vendedor)
        {
            int id = ultimoID + 1;
            ultimoID = id;
            vendedor.PessoaID = id;
            MeusVendedores.Add(vendedor);


        }

          public Vendedor PesquisarPorNome(string nome)
          {
                var v = from x in MeusVendedores
                        where x.Nome.ToLower().Contains(nome.Trim().ToLower())
                        select x;

                if (v != null)
                    return v.FirstOrDefault();
                else
                    return null;
            }

        public Vendedor PesquisarPorID(int idVendedor)
        {
            var v = from x in MeusVendedores
                    where x.PessoaID.Equals(idVendedor)
                    select x;

            if (v != null)
                return v.FirstOrDefault();
            else
                return null;
        }
        public void excluirVendedor(int idVendedor)
        { 
            Vendedor v = PesquisarPorID(idVendedor);
            if (v != null)
                MeusVendedores.Remove(v);
         }
        public List<Vendedor> ListarVendedores()
        {
            return MeusVendedores;
        }
        public void EditarVendedor(int idVendedorEditar, Vendedor VendedorEditado)
        {
            Vendedor VendedorEditar = PesquisarPorID(idVendedorEditar);

            VendedorEditar.Nome = VendedorEditado.Nome;
            VendedorEditar.Cpf = VendedorEditado.Cpf;
        }
    }
}
