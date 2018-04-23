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

        public void ExcluirVenda(int idVenda)
        {
            Venda vend = PesquisarPorID(idVenda);

            if (vend != null)
            {
                Ctx.Entry(vend).State = System.Data.Entity.EntityState.Deleted;
                Ctx.SaveChanges();
            }
        }

        public Venda PesquisarPorID(int idVenda)
        {
            var vend = from v in Ctx.tblVendas
                      where v.VendaID.Equals(idVenda)
                      select v;

            if (vend != null)
                return vend.FirstOrDefault();
            else
                return null;
        }
    }
}
