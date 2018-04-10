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
    }
}
