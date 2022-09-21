using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBackendOrenes.Dominio
{
    public class Conductor
    {
        public Guid conductorId { get; set; }

        public string nombre { get; set; }

        public string telefono { get; set; }

        public string carnetCirculacion { get; set; }

        public Vehiculo vehiculo { get; set; }

    }
}
