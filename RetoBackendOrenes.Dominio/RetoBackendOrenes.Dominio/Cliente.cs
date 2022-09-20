using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBackendOrenes.Dominio
{
    public class Cliente
    {
        public Guid clienteId { get; set; }

        public string  nombre { get; set; }

        public string  correo { get; set; }

        public string  telefono { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
