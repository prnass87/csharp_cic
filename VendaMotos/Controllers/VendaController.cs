using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class VendaController : BaseController
    {

        public void SalvaVenda(Venda venda)
        {
            Ctx.tblVendas.Add(venda);
            Ctx.SaveChanges();
        }
    }
}
