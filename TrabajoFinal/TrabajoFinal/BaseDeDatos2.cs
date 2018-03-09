using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal
{
    public class BaseDeDatos2
    {
        private string _tipo;
        public BaseDeDatos2(string Tipo)
        {
            //Leer mi archivo
            _tipo = Tipo;
            if (Tipo == "Inventario")
            {
                CargarInventarioDesdeArchivo();
            }
            else
            {
                CargarHistoricoDesdeArchivo();
            }
        }
        #region Inventario

        public int[] InventarioCantidad;
        public string[] InventarioDescripcion;
        public double[] InventarioPrecio;
        private void CargarInventarioDesdeArchivo()
        {
            try
            {
                StreamReader archivo = new StreamReader("inventario.ldmo");
                string[] registros = archivo.ReadToEnd().Split('\n');
                archivo.Close();
                //50|carteras|60
                InventarioCantidad = new int[registros.Length - 1];
                InventarioDescripcion = new string[registros.Length - 1];
                InventarioPrecio = new double[registros.Length - 1];
                for (int i = 0; i < registros.Length - 1; i++)
                {
                    string[] columnas = registros[i].Split('|');
                    InventarioCantidad[i] = int.Parse(columnas[0]);
                    InventarioDescripcion[i] = columnas[1];
                    InventarioPrecio[i] = double.Parse(columnas[2]);
                }
            }
            catch (Exception)
            {
                InventarioCantidad = new int[0];
                InventarioDescripcion = new string[0];
                InventarioPrecio = new double[0];
            }
        }
        public void AgregarAInventario(int cantidad, string descripcion, double precio)
        {
            //buscar el producto
            bool encontrado = false;
            for (int i = 0; i < InventarioDescripcion.Length; i++)
            {
                if (descripcion == InventarioDescripcion[i])
                {
                    InventarioCantidad[i] += cantidad;
                    InventarioPrecio[i] = precio;
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)//si no fue encontrado,
            {
                int[] tempCantidad = new int[InventarioCantidad.Length + 1];
                string[] tempDescripcion = new string[InventarioDescripcion.Length + 1];
                double[] tempPrecios = new double[InventarioPrecio.Length + 1];
                for (int i = 0; i < InventarioCantidad.Length; i++)
                {
                    tempCantidad[i] = InventarioCantidad[i];
                    tempDescripcion[i] = InventarioDescripcion[i];
                    tempPrecios[i] = InventarioPrecio[i];
                }
                tempCantidad[tempCantidad.Length - 1] = cantidad;
                tempDescripcion[tempDescripcion.Length - 1] = descripcion;
                tempPrecios[tempPrecios.Length - 1] = precio;
                InventarioCantidad = tempCantidad;
                InventarioDescripcion = tempDescripcion;
                InventarioPrecio = tempPrecios;
            }
        }
        public void DarDeBajaInventario(int cantidad, string descripcion)
        {
            for (int i = 0; i < InventarioDescripcion.Length; i++)
            {
                if (descripcion == InventarioDescripcion[i])
                {
                    InventarioCantidad[i] = InventarioCantidad[i] - cantidad;
                    break;
                }
            }
        }
        private void GuardarInventarioEnArchivo()
        {
            StreamWriter arcivo = new StreamWriter("inventario.ldmo");
            //50|cartera|60
            for (int i = 0; i < InventarioCantidad.Length; i++)
            {
                arcivo.WriteLine("{0}|{1}|{2}", InventarioCantidad[i], InventarioDescripcion[i], InventarioPrecio[i]);
            }
            arcivo.Close();
        }
        #endregion
        #region historico
        public string[] HistoricoCliente { get; set; }
        public DateTime[] HistoricoFechas { get; set; }
        public int[] HistoricoCantidades { get; set; }
        public string[] HistoricoProducto { get; set; }
        public double[] HistoricosPrecios { get; set; }
        public void AgregarAHistorico(string cliente, DateTime fecha, int cantidad, string producto, double precio)
        {
            string[] tempClientes = new string[HistoricoCliente.Length + 1];
            DateTime[] tempFechas = new DateTime[HistoricoFechas.Length + 1];
            int[] temCantidades = new int[HistoricoCantidades.Length + 1];
            string[] tempProductos = new string[HistoricoProducto.Length + 1];
            double[] temPrecios = new double[HistoricosPrecios.Length + 1];
            for (int i = 0; i < HistoricoCliente.Length; i++)
            {
                temCantidades[i] = HistoricoCantidades[i];
                tempClientes[i] = HistoricoCliente[i];
                tempFechas[i] = HistoricoFechas[i];
                temPrecios[i] = HistoricosPrecios[i];
                tempProductos[i] = HistoricoProducto[i];
            }
            temCantidades[temCantidades.Length - 1] = cantidad;
            tempClientes[tempClientes.Length - 1] = cliente;
            tempFechas[tempFechas.Length - 1] = fecha;
            temPrecios[temPrecios.Length - 1] = precio;
            tempProductos[tempProductos.Length - 1] = producto;
            HistoricoCantidades = temCantidades;
            HistoricoCliente = tempClientes;
            HistoricoFechas = tempFechas;
            HistoricosPrecios = temPrecios;
            HistoricoProducto = tempProductos;
        }
        private void GuardarHistoricoEnArchivo()
        {
            StreamWriter archivo = new StreamWriter("historico.ldmo");
            for (int i = 0; i < HistoricoCantidades.Length; i++)
            {
                archivo.WriteLine("{0}|{1}|{2}|{3}|{4}", HistoricoCliente[i], HistoricoFechas[i], HistoricoCantidades[i], HistoricoProducto[i], HistoricosPrecios[i]);
            }
            archivo.Close();
        }
        private void CargarHistoricoDesdeArchivo()
        {
            try
            {
                StreamReader archivo = new StreamReader("historico.ldmo");
                string[] lineas = archivo.ReadToEnd().Split('\n');
                archivo.Close();
                HistoricoCantidades = new int[lineas.Length - 1];
                HistoricoCliente = new string[lineas.Length - 1];
                HistoricoFechas = new DateTime[lineas.Length - 1];
                HistoricoProducto = new string[lineas.Length - 1];
                HistoricosPrecios = new double[lineas.Length - 1];
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] columnas = lineas[i].Split('|');
                    HistoricoCliente[i] = columnas[0];
                    HistoricoFechas[i] = DateTime.Parse(columnas[1]);
                    HistoricoCantidades[i] = int.Parse(columnas[2]);
                    HistoricoProducto[i] = columnas[3];
                    HistoricosPrecios[i] = double.Parse(columnas[4]);
                }
            }
            catch (Exception)
            {
                HistoricoCantidades = new int[0];
                HistoricoCliente = new string[0];
                HistoricoFechas = new DateTime[0];
                HistoricosPrecios = new double[0];
                HistoricoProducto = new string[0];
            }
        }
        #endregion
        ~BaseDeDatos2()
        {
            if (_tipo == "Inventario")
            {
                GuardarInventarioEnArchivo();
            }
            else
            {
                GuardarHistoricoEnArchivo();
            }
        }
    }
}
