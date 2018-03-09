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

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para GenerarVenta.xaml
    /// </summary>
    public partial class GenerarVenta : Window
    {
        private Inventario2 _inventario;
        RepositorEmpleado repositor;
        //private Historico _historico;
        private double _totalVenta = 0;
        public GenerarVenta()
        {
            InitializeComponent();
            repositor = new RepositorEmpleado();
            cmbMaterias.ItemsSource = repositor.Leerempleados();
            _inventario = new Inventario2();
            //_historico = new Historico();
            for (int i = 0; i < _inventario.Cantidades.Length; i++)
            {
                cmbProducto.Items.Add(_inventario.Descripciones[i]);
            }
            dgvProductos.Columns[0].HeaderText = "Cantidad";
            dgvProductos.Columns[1].HeaderText = "Nombre";
            dgvProductos.Columns[2].HeaderText = "Precio compra";
            dgvProductos.Columns[3].HeaderText = "Precio Venta";
            dgvProductos.Columns[1].Width = 150;
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbProducto.Text == "")
            {
                return;
            }
            int cantidadExistente = 0;
            double precio = 0;
             
            if (_inventario.PuedoVenderProduct(cmbProducto.Text, (int)nudCantidad.Value , out precio, out cantidadExistente))
            {
                dgvProductos.Rows.Add();
                dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[0].Value = (int)nudCantidad.Value;
                dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[1].Value = cmbProducto.Text;
                dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[2].Value = precio;
                dgvProductos.Rows[dgvProductos.RowCount - 1].Cells[3].Value = (int)nudCantidad.Value * precio;
                CalcularTotal();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No podemos vender esta cantidad de " + cmbProducto.Text + ",solo existen" + cantidadExistente + ";ingrese otra cantidad...", "Mi Pequenio Enfermito", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }

        private void CalcularTotal()
        {
            double total = 0;
            for (int i = 0; i < dgvProductos.RowCount; i++)
            {
                total += double.Parse(dgvProductos.Rows[i].Cells[3].Value.ToString());
            }
            txbTotal.Text = "Total: $" + total;
            _totalVenta = total;
        }

        private void btnGenerarVenta_Click(object sender, RoutedEventArgs e)
        {
            if (_totalVenta > 0)
            {
                //Calcular el cambio
                if (double.Parse(txtCantidad.Text) > _totalVenta)
                {
                    double cambio = double.Parse(txtCantidad.Text) - _totalVenta;
                    //Generar el archivo de ventas
                    int selectedIndex = cmbMaterias.SelectedIndex;
                    Object selectedItem = cmbMaterias.SelectedItem;
                    ArchivoVenta1 archivo = new ArchivoVenta1();
                    if (archivo.Genrar(txtNombreCliente.Text,txtRFC.Text,txtTel.Text,txtDireccion.Text,txtEmail.Text, selectedItem.ToString(), ObtenerDatos(), double.Parse(txtCantidad.Text), _totalVenta, cambio, txtNombreCliente.Text + ".ldmo"))
                    {
                        //disminuir el inventario
                        // agregar el histórico de ventas
                        for (int i = 0; i < dgvProductos.RowCount; i++)
                        {
                            _inventario.Eliminar(int.Parse(dgvProductos.Rows[i].Cells[0].Value.ToString()), dgvProductos.Rows[i].Cells[1].Value.ToString());
                            // _historico.Agregar(txtNombreCliente.Text, DateTime.Now, int.Parse(dgvProductos.Rows[i].Cells[0].Value.ToString()), dgvProductos.Rows[i].Cells[1].Value.ToString(), double.Parse(dgvProductos.Rows[i].Cells[2].Value.ToString()));
                        }
                        MessageBox.Show("Venta guardada correctamente; cambio: $" + cambio, "Mi Pequenio Enfermito", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgvProductos.RowCount = 0;
                        txtNombreCliente.Text = "";
                        txtCantidad.Text = "";
                        txbTotal.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la venta", "Mi Pequenio Enfermito", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {
                    MessageBox.Show("La cantidad no es suficiente para cubrir el monto", "Mi Pequenio Enfermito", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No hay elementos a vender", "Mi Pequenio Enfermito", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }

        private string[,] ObtenerDatos()
        {
            string[,] datos = new string[dgvProductos.ColumnCount, dgvProductos.RowCount];
            for (int colmna = 0; colmna < dgvProductos.ColumnCount; colmna++)
            {
                for (int fila = 0; fila < dgvProductos.RowCount; fila++)
                {
                    datos[colmna, fila] = dgvProductos.Rows[fila].Cells[colmna].Value.ToString();
                }
            }
            return datos;
        }
    }
}
