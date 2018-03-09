using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal
{
    class ArchivoVenta1
    {
        public bool Genrar(string nombreCliente,string RFC ,string Tel,string Direccion, string Email,string Empleado, string[,] datos, double cantidad, double cantidadVenta, double cambio, string ruta)
        {
            try
            {
                StreamWriter archivo = new StreamWriter(ruta);
                archivo.WriteLine("Mi Pequeño Enfermito");
                archivo.WriteLine("Fecha: " + DateTime.Now.ToLongDateString());
                archivo.WriteLine("Cliente: " + nombreCliente);
                archivo.WriteLine("RFC: " + RFC);
                archivo.WriteLine("Telefono: " + Tel);
                archivo.WriteLine("Direccion: " + Direccion);
                archivo.WriteLine("Email: " + Email);
                archivo.WriteLine("Empeado: " + Empleado);
                archivo.WriteLine("\nCant.\tDescripcion\tPrecio\tImporte");
                for (int filas = 0; filas < datos.GetLength(1); filas++)
                {
                    for (int columnsa = 0; columnsa < datos.GetLength(0); columnsa++)
                    {
                        archivo.Write("{0}\t", datos[columnsa, filas]);
                    }
                    archivo.WriteLine();
                }
                archivo.WriteLine("total: $" + cantidadVenta);
                archivo.WriteLine("Su pago: $" + cantidad);
                archivo.WriteLine("Cambio: $" + cambio);
                archivo.WriteLine("GRACIAS POR COMPRAR CON NOSOTROS");
                archivo.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
