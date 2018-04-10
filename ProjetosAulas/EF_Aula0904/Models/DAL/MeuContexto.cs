using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Aula0904.Models.DAL
{
    public class MeuContexto : DbContext
    {

        public MeuContexto() : base("strConn") //Nome da string de conexao
        {

        }

        public DbSet<Cliente> tblClientes { get; set; }

        

    }
}
