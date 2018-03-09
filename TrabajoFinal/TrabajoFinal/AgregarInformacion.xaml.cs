using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para AgregarInformacion.xaml
    /// </summary>
    public partial class AgregarInformacion : Window
    {
        public AgregarInformacion()
        {
            InitializeComponent();
            dgvProductos.Columns[0].HeaderCell.Value = "Cantidad";
            dgvProductos.Columns[1].HeaderCell.Value = "Nombre";
            dgvProductos.Columns[2].HeaderCell.Value = "Precio Compra ";
            dgvProductos.Columns[3].HeaderCell.Value = "Precio Venta";

        }
        private void btnSeleccionarArchivo_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialogo = new System.Windows.Forms.OpenFileDialog();
            dialogo.Title = "Selecciona el archivo del proveedor";
            dialogo.Filter = "Archivos de proveedores | *.txt";
            if (dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader archivo = new StreamReader(dialogo.FileName);
                string[] contenido = archivo.ReadToEnd().Split('\n');
                archivo.Close();
                txtProveedor.Text = contenido[0];
                dgvProductos.Rows.Clear();
                for (int i = 1; i < contenido.Length; i++)
                {
                    string[] columnas = contenido[i].Split('|');
                    if (columnas.Length > 1)
                    {
                        dgvProductos.Rows.Add();
                        dgvProductos.Rows[i - 1].Cells[0].Value = columnas[0];
                        dgvProductos.Rows[i - 1].Cells[1].Value = columnas[1];
                        dgvProductos.Rows[i - 1].Cells[2].Value = columnas[2];
                        dgvProductos.Rows[i - 1].Cells[3].Value = columnas[3];

                    }
                }
            }
            else
            {
                MessageBox.Show("Proceso cancelado por el usuario", "Mi Pequenio Enfermito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            Inventario2 inventario = new Inventario2();
            for (int i = 0; i < dgvProductos.RowCount; i++)
            {
                inventario.Agregar(int.Parse(dgvProductos.Rows[i].Cells[0].Value.ToString()), dgvProductos.Rows[i].Cells[1].Value.ToString(), double.Parse(dgvProductos.Rows[i].Cells[2].Value.ToString()) * (1 + ((double)nudPorcIncremento.Value / 100)));
            }
            MessageBox.Show("Productos agregados al inventario correctamente", "Mi Pequenio Enfemito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
