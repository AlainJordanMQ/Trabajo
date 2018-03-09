using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal
{
    public class Inventario2
    {
        BaseDeDatos2 db = new BaseDeDatos2("Inventario");
        public int[] Cantidades
        {
            get
            {
                return db.InventarioCantidad;
            }
        }
        public string[] Descripciones
        {
            get
            {
                return db.InventarioDescripcion;
            }
        }
        public double[] Precios
        {
            get
            {
                return db.InventarioPrecio;
            }
        }
        public void Agregar(int cantidad, string descripcion, double precio)
        {
            db.AgregarAInventario(cantidad, descripcion, precio);
        }
        public void Eliminar(int cantidad, string descripcion)
        {
            db.DarDeBajaInventario(cantidad, descripcion);
        }
        /// <summary>
        /// Busca un producto y verifica si se tiene la cantidad adecuada en el inventario
        /// </summary>
        /// <param name="producto">Nombre del producto a buscar</param>
        /// <param name="cantidad">Cantidad solicitada para vender</param>
        /// <param name="precio">Precio del Producto</param>
        /// <param name="cantidadExistente">Cantidad Existente en inventario</param>
        /// <returns>True si es que se puede vender el producto</returns>
        public bool PuedoVenderProduct(string producto, int cantidad, out double precio, out int cantidadExistente)
        {
            int posicion = -1;
            for (int i = 0; i < Descripciones.Length; i++)
            {
                if (Descripciones[i] == producto)
                {
                    //ya encontré el producto
                    posicion = i;
                    break;
                }
            }
            precio = Precios[posicion];
            cantidadExistente = Cantidades[posicion];
            if (cantidad <= Cantidades[posicion])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
