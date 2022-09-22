using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Infrastructura.Datos.Context;


namespace RetoBackendOrenes.Infrastructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Si no existe, se creará la Base de datos...");
            RetoContext db = new RetoContext();
            try
            {
                db.Database.EnsureCreated();
                Console.WriteLine("Se ha creado correctamente");
            }
            catch(Exception e)
            {
                Console.WriteLine("No se ha podido crear la Base de datos.");
            }
            Console.ReadKey();
        }
    }
}
