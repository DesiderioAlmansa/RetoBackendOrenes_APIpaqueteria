using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBackendOrenes.Dominio
{
    public class Pedido
    {
        public Guid numeroPedido { get; set; }

        public Guid cliente { get; set; }

        public string direccionEnvio { get; set; }

        public int bultos { get; set; }

        public decimal importeTotal { get; set; }

        public Guid vehiculo { get; set; }

        public DateTime fechaCreacion { get; set; }

        public bool entregado { get; set; }

        public Cliente Cliente { get; set; }

        public Vehiculo Vehiculo { get; set; }
    }
}
