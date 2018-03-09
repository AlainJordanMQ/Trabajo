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
    /// Lógica de interacción para NuevaCategoria.xaml
    /// </summary>
    public partial class NuevaCategoria : Window
    {
        RepositorDeProducto repositorio;
        bool esNuevo;
        public NuevaCategoria( string NombreCategoria)
        {
            InitializeComponent();
            repositorio = new RepositorDeProducto(NombreCategoria);
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbNombreCategoria.Clear();
            txbNombreProducto.Clear();
            txbPrecioCompra.Clear();
            txbPrecioVenta.Clear();
            txbNombreCategoria.IsEnabled = habilitadas;
            txbNombreProducto.IsEnabled = habilitadas;
            txbPrecioCompra.IsEnabled = habilitadas;
            txbPrecioVenta.IsEnabled = habilitadas;
        }

        private void HabilitarBotones(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(true);
            HabilitarBotones(false);
            esNuevo = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajas(false);
            HabilitarBotones(true);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreCategoria.Text) || string.IsNullOrEmpty(txbNombreProducto.Text) || string.IsNullOrEmpty(txbPrecioCompra.Text) || string.IsNullOrEmpty(txbPrecioVenta.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Producto a = new Producto()
                {
                    Cantida = txbNombreCategoria.Text,
                    NombreProducto = txbNombreProducto.Text,
                    PrecioCompra = txbPrecioCompra.Text,
                    PrecioVenta = txbPrecioVenta.Text
                };
                if (repositorio.AgregarProducto(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Producto original = dtgTabla.SelectedItem as Producto;
                Producto a = new Producto();
                a.Cantida = txbNombreCategoria.Text;
                a.NombreProducto = txbNombreProducto.Text;
                a.PrecioCompra = txbPrecioCompra.Text;
                a.PrecioVenta = txbPrecioVenta.Text;
                if (repositorio.ModificarAmigo(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su Categoria a sido actualizado", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Categoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ActualizarTabla()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = repositorio.LeerProductos();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProductos().Count == 0)
            {
                MessageBox.Show("Error...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Producto a = dtgTabla.SelectedItem as Producto;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.NombreProducto + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarProductos(a))
                        {
                            MessageBox.Show("Tu Elemento ha sido removido", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar a tu elemento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Elemento", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.LeerProductos().Count == 0)
            {
                MessageBox.Show("Error...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Producto a = dtgTabla.SelectedItem as Producto;
                    HabilitarCajas(true);
                    txbNombreCategoria.Text = a.Cantida;
                    txbNombreProducto.Text = a.NombreProducto;
                    txbPrecioCompra.Text = a.PrecioCompra;
                    txbPrecioVenta.Text = a.PrecioVenta;
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Catgoria", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
