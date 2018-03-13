using Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    public class ClienteController
    {
        //Controle de acesso
        static List<Cliente> MeusClientes = new List<Cliente>();

        public void SalvarCliente(Cliente cliente)
        {
            //TODO: Persistir os dados do cliente.
            MeusClientes.Add(cliente);
        }

        public Cliente PesquisarPorNome(string nome)
        {

            /*
             - Trim(): Remoção de espaços
             - toLower(): letras em minusculo
             - ToUpper(): letras em maisculo
             - Equals():
             - Contains():
             */

            var c = from x in MeusClientes
                    where x.Nome.ToLower().Equals(nome.Trim().ToLower())
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }
    }
}
