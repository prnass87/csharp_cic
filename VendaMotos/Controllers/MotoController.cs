using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class MotoController
    {
        static List<Moto> MinhasMotos = new List<Moto>();
        static int ultimoID = 0;

        public void SalvarMoto(Moto moto)
        {
            int id = ultimoID + 1;
            ultimoID = 1;
            moto.MotoID = id;
            MinhasMotos.Add(moto);
        }

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
    }
}
