using Models;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class MotoController
    {

        public void SalvarMoto(Moto moto)
        {
            Contexto ctx = new Contexto();
            ctx.tblMotos.Add(moto);
            ctx.SaveChanges();
        }
        /*
        public Moto PesquisarPorModelo(string nome)
        {
            var m = from x in MinhasMotos
                    where x.Modelo.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (m != null)
                return m.FirstOrDefault();
            else
                return null;
        }

        public Moto PesquisarPorID(int idMoto)
        {
            var m = from x in MinhasMotos
                    where x.MotoID.Equals(idMoto)
                    select x;

            if (m != null)
                return m.FirstOrDefault();
            else
                return null;
        }

        public void ExcluirMoto(int idMoto)
        {
            Moto mto = PesquisarPorID(idMoto);
            if (mto != null)
            {
                MinhasMotos.Remove(mto);
            }
        }

        public List<Moto> ListarMotos()
        {
            return MinhasMotos;
        }

        public void EditarMoto(int idMotoEditar, Moto MotoEditada)
        {
            Moto MotoEditar = PesquisarPorID(idMotoEditar);

            MotoEditar.Marca = MotoEditada.Marca;
            MotoEditar.Modelo = MotoEditada.Modelo;
            MotoEditar.Cilindrada = MotoEditada.Cilindrada;
            MotoEditar.Ano = MotoEditada.Ano;
            MotoEditar.Cor = MotoEditada.Cor;
            MotoEditar.Placa = MotoEditada.Placa;
            MotoEditar.Valor = MotoEditada.Valor;
            MotoEditar.Status = MotoEditada.Status;

        }
        */
    }
}
