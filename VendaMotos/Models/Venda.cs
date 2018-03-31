using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Venda
    {
        public int MotoID { get; set; }
        public Moto _Moto { get; set; }

        public int VendedorID { get; set; }
        public Vendedor _Vendedor { get; set; }

        public int ClienteID { get; set; }
        public Cliente _Cliente { get; set; }
    }
}
