using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal
{
    class RepositorEmpleado
    {
        ManejadorDeArchivos2 archivo;
        List<Empleado2> empleados;
        public RepositorEmpleado()
        {
            archivo = new ManejadorDeArchivos2("NuevoEmpleado2.txt");
            empleados = new List<Empleado2>();
        }


        public bool AgregarProducto(Empleado2 empleado2)
        {
            empleados.Add(empleado2);
            bool resultado = ActualizarArchivo();
            empleados = Leerempleados();
            return resultado;
        }

        public bool EliminarProductos(Empleado2 empleado2)
        {
            Empleado2 temporal = new Empleado2();
            foreach (var item in empleados)
            {
                if (item.Nombre == empleado2.Nombre)
                {
                    temporal = item;
                }
            }
            empleados.Remove(temporal);
            bool resultado = ActualizarArchivo();
            empleados = Leerempleados();
            return resultado;
        }

        public bool ModificarAmigo(Empleado2 original, Empleado2 modificado)
        {
            Empleado2 temporal = new Empleado2();
            foreach (var item in empleados)
            {
                if (original.Nombre == item.Nombre)
                {
                    temporal = item;
                }
            }
            //temporal.NombreCategoria = modificado.NombreCategoria;
            //temporal.Cantida = modificado.Cantida;
            temporal.Nombre = modificado.Nombre;
            //temporal.Descripcion = modificado.Descripcion;
            //temporal.PrecioCompra = modificado.PrecioCompra;
            //temporal.PrecioVenta = modificado.PrecioVenta;
            bool resultado = ActualizarArchivo();
            empleados = Leerempleados();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Empleado2 item in empleados)
            {
                datos += string.Format(" {0} \n", item.Nombre);
            }
            return archivo.Guardar(datos);
        }
        public List<Empleado2> Leerempleados()
        {
            string datos = archivo.Leer();
            if (datos != null)
            {
                List<Empleado2> emple = new List<Empleado2>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    if (i == 0)
                    {

                    }
                    else
                    {
                        string[] campos = lineas[i].Split('|');
                        Empleado2 a = new Empleado2()
                        {
                            //Cantida = campos[0],
                            Nombre = campos[0],
                            //Descripcion = campos[2],
                           // PrecioVenta = campos[2],
                           // PrecioCompra = campos[3]
                        };
                        emple.Add(a);
                    }
                }
                empleados = emple;
                return emple;
            }
            else
            {
                return null;
            }
        }

    }
}
