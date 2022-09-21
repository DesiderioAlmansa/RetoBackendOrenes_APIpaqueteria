using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBackendOrenes.Dominio
{
    public class LogCambiosUbicacion
    {
        public Guid logId { get; set; }

        public Guid vehiculoId { get; set; }

        public DateTime fechaCambio { get; set; }

        public string ubicacionAnterior { get; set; }

        public string ubicacionNueva { get; set; }

        public Vehiculo Vehiculo { get; set; }
    }
}
