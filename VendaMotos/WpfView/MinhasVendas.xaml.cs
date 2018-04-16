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

namespace WpfView
{
    /// <summary>
    /// Lógica interna para MinhasVendas.xaml
    /// </summary>
    public partial class MinhasVendas : Window
    {
        public MinhasVendas()
        {
            InitializeComponent();
        }

        private void btnNovaVenda_Click(object sender, RoutedEventArgs e)
        {
            EfetuarVenda nova_tela = new EfetuarVenda();
            nova_tela.Show();
        }

        private void dtgMinhasVendas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
