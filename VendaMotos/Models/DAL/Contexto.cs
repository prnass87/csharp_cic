using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base ("strConn") //Nome da string de conexão
        {

        }

        public DbSet<Cliente> tblClientes { get; set; }
        public DbSet<Endereco> tblEnderecos { get; set; }
        public DbSet<Moto> tblMotos { get; set; }
        public DbSet<Venda> tblVendas { get; set; }
        public DbSet<Vendedor> tblVendedores { get; set; }

    }
}
