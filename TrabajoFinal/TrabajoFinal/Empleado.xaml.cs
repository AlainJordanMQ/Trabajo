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
    /// Lógica de interacción para Empleado.xaml
    /// </summary>
    public partial class Empleado : Window
    {
        RepositorEmpleado repositorio;
        bool esNuevo;
        public Empleado()
        {
            InitializeComponent();
            repositorio = new RepositorEmpleado();
            HabilitarCajas(false);
            HabilitarBotones(true);
            ActualizarTabla();
        }
        private void HabilitarCajas(bool habilitadas)
        {
            txbNombreCategoria.Clear();
            
            txbNombreCategoria.IsEnabled = habilitadas;
           
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
            if (string.IsNullOrEmpty(txbNombreCategoria.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (esNuevo)
            {

                Empleado2 a = new Empleado2()
                {
                    Nombre = txbNombreCategoria.Text,
                
                };
                if (repositorio.AgregarProducto(a))
                    
                {
                    MessageBox.Show("Guardado con Éxito", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado2 original = dtgTabla.SelectedItem as Empleado2;
                Empleado2 a = new Empleado2();
                a.Nombre = txbNombreCategoria.Text;
                
                if (repositorio.ModificarAmigo(original, a))
                {
                    HabilitarBotones(true);
                    HabilitarCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su Empleado a sido actualizado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu Empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ActualizarTabla()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = repositorio.Leerempleados();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.Leerempleados().Count == 0)
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Empleado2 a = dtgTabla.SelectedItem as Empleado2;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (repositorio.EliminarProductos(a))
                        {
                            MessageBox.Show("Tu Empleado ha sido removido", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar a tu Empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (repositorio.Leerempleados().Count == 0)
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
                   
                    HabilitarBotones(false);
                    esNuevo = false;
                }
                else
                {
                    MessageBox.Show("¿A Quien???", "Empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }
    }
}
