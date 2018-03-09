using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal
{
    class RepositorDeProducto
    {
        ManejadorDeArchivos2 archivo;
        List<Producto> Productos;

        public RepositorDeProducto(string NombreCategoria)
        {

            archivo = new ManejadorDeArchivos2(NombreCategoria+".txt");

            Productos = new List<Producto>();
        }



        public bool AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
            bool resultado = ActualizarArchivo();
            Productos = LeerProductos();
            return resultado;
        }

        public bool EliminarProductos(Producto producto)
        {
            Producto temporal = new Producto();
            foreach (var item in Productos)
            {
                if (item.NombreProducto == producto.NombreProducto)
                {
                    temporal = item;
                }
            }
            Productos.Remove(temporal);
            bool resultado = ActualizarArchivo();
            Productos = LeerProductos();
            return resultado;
        }

        public bool ModificarAmigo(Producto original, Producto modificado)
        {
            Producto temporal = new Producto();
            foreach (var item in Productos)
            {
                if (original.NombreProducto == item.NombreProducto)
                {
                    temporal = item;
                }
            }
            //temporal.NombreCategoria = modificado.NombreCategoria;
            temporal.Cantida = modificado.Cantida;
            temporal.NombreProducto = modificado.NombreProducto;
            //temporal.Descripcion = modificado.Descripcion;
            temporal.PrecioCompra = modificado.PrecioCompra;
            temporal.PrecioVenta = modificado.PrecioVenta;
            bool resultado = ActualizarArchivo();
            Productos = LeerProductos();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Producto item in Productos)
            {
                datos += string.Format(" {0} | {1} | {2} | {3} \n", item.Cantida, item.NombreProducto, item.PrecioVenta, item.PrecioCompra);
            }
            return archivo.Guardar(datos);
        }
        public List<Producto> LeerProductos()
        {
            string datos = archivo.Leer();
            if (datos != null)
            {
                List<Producto> productos = new List<Producto>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    if (i == 0)
                    {

                    }
                    else
                    {
                        string[] campos = lineas[i].Split('|');
                        Producto a = new Producto()
                        {
                            Cantida = campos[0],
                            NombreProducto = campos[1],
                            //Descripcion = campos[2],
                            PrecioVenta = campos[2],
                            PrecioCompra = campos[3]
                        };
                        productos.Add(a);
                    }
                }
                Productos = productos;
                return productos;
            }
            else
            {
                return null;
            }
        }
    }
}
