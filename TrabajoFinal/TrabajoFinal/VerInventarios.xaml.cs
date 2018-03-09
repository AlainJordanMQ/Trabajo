using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para VerInventarios.xaml
    /// </summary>
    public partial class VerInventarios : Window
    {
        public VerInventarios()
        {
            InitializeComponent();
            InitializeComponent();
            dgvProductos.Columns[0].HeaderText = "Cantidad";
            dgvProductos.Columns[1].HeaderText = "Descripción";
            dgvProductos.Columns[2].HeaderText = "Precios";
        }
        private void btnMostrarInventario_Click(object sender, RoutedEventArgs e)
        {
            Inventario2 inventario = new Inventario2();
            dgvProductos.Rows.Clear();
            if ((bool)chkVerCeroUnidades.IsChecked)
            {
                //mostrar todo
                for (int i = 0; i < inventario.Cantidades.Length; i++)
                {
                    dgvProductos.RowCount += 1;
                    dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[0].Value = inventario.Cantidades[i];
                    dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[1].Value = inventario.Descripciones[i];
                    dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[2].Value = inventario.Precios[i];
                }
            }
            else
            {
                //mostrar solo las unidades > 0
                for (int i = 0; i < inventario.Cantidades.Length; i++)
                {
                    if (inventario.Cantidades[i] > 0)
                    {
                        dgvProductos.RowCount += 1;
                        dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[0].Value = inventario.Cantidades[i];
                        dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[1].Value = inventario.Descripciones[i];
                        dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[2].Value = inventario.Precios[i];
                    }
                }
            }

        }

        

        private string[,] OtenerDatos(DataGridView dgvProductos)
        {
            string[,] datos = new string[dgvProductos.ColumnCount, dgvProductos.RowCount];
            for (int columnas = 0; columnas < dgvProductos.ColumnCount; columnas++)
            {
                for (int fila = 0; fila < dgvProductos.RowCount; fila++)
                {
                    datos[columnas, fila] = dgvProductos.Rows[fila].Cells[columnas].Value.ToString();
                }
            }
            return datos;
        }

        private string[] ObtenerTitulos(DataGridView dgvProductos)
        {
            string[] titulos = new string[dgvProductos.ColumnCount];
            for (int i = 0; i < dgvProductos.ColumnCount; i++)
            {
                titulos[i] = dgvProductos.Columns[i].HeaderText;
            }
            return titulos;
        }
    }
}
