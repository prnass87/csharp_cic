﻿using Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    public class ClienteController
    {
        //Controle de acesso
        static List<Cliente> MeusClientes = new List<Cliente>();
        static int ultimoID = 0;

        public void SalvarCliente(Cliente cliente)
        {
            //TODO: Persistir os dados do cliente.
            int id = ultimoID + 1;
            ultimoID = id;
            cliente.PessoaID = id;
            MeusClientes.Add(cliente);
        }

        public Cliente PesquisarPorNome(string nome)
        {

            /*
             - Trim(): Remoção de espaços
             - toLower(): letras em minusculo
             - ToUpper(): letras em maisculo
             - Equals():
             - Contains():
             */

            var c = from x in MeusClientes
                    where x.Nome.ToLower().Contains(nome.Trim().ToLower())
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public Cliente PesquisarPorID(int idCliente)
        {
            var c = from x in MeusClientes
                    where x.PessoaID.Equals(idCliente)
                    select x;

            if (c != null)
                return c.FirstOrDefault();
            else
                return null;
        }

        public void ExcluirCliente(int idCliente)
        {
            Cliente cli = PesquisarPorID(idCliente);
            if (cli != null)
            MeusClientes.Remove(cli);
        }
    }
}
