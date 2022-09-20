using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBackendOrenes.Dominio
{
    public class Vehiculo
    {
        public Guid vehiculoId { get; set; }

        public Guid conductor { get; set; }

        public int pedidosPendientes { get; set; }

        public string ubicacionActual { get; set; }

        public Conductor Conductor { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public List<LogCambiosUbicacion> Logs_CambiosUbicacion { get; set; }

    }
}
