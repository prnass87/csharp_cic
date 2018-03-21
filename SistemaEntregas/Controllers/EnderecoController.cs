using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class EnderecoController
    {
        static List<Endereco> EnderecoCadastrados = new List<Endereco>();
        static int ultimoId = 0;

        public void SalvarEndereco(Endereco endereco)
        {
            int id = ultimoId + 1;
            ultimoId = id;
            endereco.EnderecoID = id;
            EnderecoCadastrados.Add(endereco);
        }

        public Endereco PesquisarPorId(int idEndereco)
        {
            var e = from x in EnderecoCadastrados
                    where x.EnderecoID.Equals(idEndereco)
                    select x;
            if (e != null)
                return e.FirstOrDefault();
            else
                return null;
        }
    }
}
