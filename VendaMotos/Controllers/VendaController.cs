using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class VendaController
    {
        static List<Venda> MinhasVendas = new List<Venda>();
        static int ultimoID = 0;

        public void GerarVenda(Venda venda)
        {
            int id = ultimoID + 1;
            ultimoID = id;

            venda.VendaID = id;
            MinhasVendas.Add(venda);
        }
    }
}
