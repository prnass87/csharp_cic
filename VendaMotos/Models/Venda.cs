﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Venda
    {
        //Informações: VENDA
        public int VendaID { get; set; }
        public DateTime DataVenda { get; set; }

        //Informações: MOTO
        public int MotoID { get; set; }
        public Moto _Moto { get; set; }

        //Informações: VENDEDOR
        public int VendedorID { get; set; }
        public Vendedor _Vendedor { get; set; }

        //Informações: CLIENTE
        public int ClienteID { get; set; }
        public Cliente _Cliente { get; set; }
    }
}
