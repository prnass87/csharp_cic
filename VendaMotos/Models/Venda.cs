using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Venda
    {
        //Informações: VENDA
        [Key]
        public int VendaID { get; set; }
        public DateTime DataVenda { get; set; }

        //Informações: MOTO
        public int MotoID { get; set; }
        public virtual Moto _Moto { get; set; }

        //Informações: VENDEDOR
        public int VendedorID { get; set; }
        public virtual Vendedor _Vendedor { get; set; }

        //Informações: CLIENTE
        public int ClienteID { get; set; }
        public virtual Cliente _Cliente { get; set; }
    }
}
