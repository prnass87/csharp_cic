﻿using Modelos;
using System.Collections.Generic;

namespace Controllers
{
    public class ClienteController
    {
        //Controle de acesso
        static List<Cliente> MeusClientes = new List<Cliente>();

        public void SalvarCliente(Cliente cliente)
        {
            //TODO: Persistir os dados do cliente.
            MeusClientes.Add(cliente);
        }
    }
}
