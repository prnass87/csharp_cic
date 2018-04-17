using Models;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class EnderecoController
    {

        public void SalvarEndereco(Endereco endereco)
        {
            Contexto ctx = new Contexto();
            ctx.tblEnderecos.Add(endereco);
            ctx.SaveChanges();
        }
        /*
        public Endereco PesquisarPorId(int idEndereco)
        {
            var e = from x in EnderecosCadastrados
                    where x.EnderecoID.Equals(idEndereco)
                    select x;
            if (e != null)
                return e.FirstOrDefault();
            else
                return null;
        }

        public void ExcluirEndereco(int idEndereco)
        {
            Endereco end = PesquisarPorId(idEndereco);
            if (end != null)
                EnderecosCadastrados.Remove(end);
        }

        public List<Endereco> ListarEnderecos()
        {
            return EnderecosCadastrados;
        }
        */
    }
}
