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

    }
}
