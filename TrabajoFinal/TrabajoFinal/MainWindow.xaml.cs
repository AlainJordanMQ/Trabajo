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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrabajoFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnIngresarInformacion_Click(object sender, RoutedEventArgs e)
        {
            AgregarInformacion v = new AgregarInformacion();
            v.Show();
        }

        private void btnInventarios_Click(object sender, RoutedEventArgs e)
        {
            VerInventarios v = new VerInventarios();
            v.Show();
        }

        /*private void btnHistorico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoVenta v = new HistoricoVenta();
            v.Show();
        }*/

        private void btnVenta_Click(object sender, RoutedEventArgs e)
        {
            GenerarVenta v = new GenerarVenta();
            v.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNuevaCategoria_Click(object sender, RoutedEventArgs e)
        {
            _1Categoria v = new _1Categoria();
            v.Show();
        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Empleado v = new Empleado();
            v.Show();

        }
    }
}
