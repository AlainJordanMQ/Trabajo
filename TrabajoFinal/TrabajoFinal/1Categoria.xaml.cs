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
    /// Lógica de interacción para _1Categoria.xaml
    /// </summary>
    public partial class _1Categoria : Window
    {
        public _1Categoria()
        {
            InitializeComponent();
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            string NombreCategoria = txtNombreCategoria.Text;
            NuevaCategoria v = new NuevaCategoria(NombreCategoria);
            v.Show();
        }
    }
}
