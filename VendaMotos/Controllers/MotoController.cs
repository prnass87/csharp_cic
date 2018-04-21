using Models;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class MotoController : BaseController
    {

        public void SalvarMoto(Moto moto)
        {
            Ctx.tblMotos.Add(moto);
            Ctx.SaveChanges();
        }

        public void ExcluirMoto(int idMoto)
        {
            Moto mot = PesquisarPorID(idMoto);

            if (mot != null)
            {
                Ctx.Entry(mot).State = System.Data.Entity.EntityState.Deleted;
                Ctx.SaveChanges();
            }
        }

        public void EditarMoto(int idMotoEditar, Moto MotoEditado)
        {
            Moto MotoEditar = PesquisarPorID(idMotoEditar);

            MotoEditar.Marca = MotoEditado.Marca;
            MotoEditar.Modelo = MotoEditado.Modelo;
            MotoEditar.Cilindrada = MotoEditado.Cilindrada;
            MotoEditar.Ano = MotoEditado.Ano;
            MotoEditar.Cor = MotoEditado.Cor;
            MotoEditar.Placa = MotoEditado.Placa;
            MotoEditar.Valor = MotoEditado.Valor;
            MotoEditar.Status = MotoEditado.Status;


            Ctx.Entry(MotoEditar).State = System.Data.Entity.EntityState.Modified;
            Ctx.SaveChanges();
        }

        public Moto PesquisarPorModelo(string modelo)
        {
            var mot = (from m in Ctx.tblMotos
                       where m.Modelo.Contains(modelo)
                       select m).First();

            if (mot != null)
                return mot;
            else
                return null;
        }

        public Moto PesquisarPorID(int idMoto)
        {
            var mot = from x in Ctx.tblMotos
                      where x.MotoID.Equals(idMoto)
                      select x;

            if (mot != null)
                return mot.FirstOrDefault();
            else
                return null;
        }
    }
}
