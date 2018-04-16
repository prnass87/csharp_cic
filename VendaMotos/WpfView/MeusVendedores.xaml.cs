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
    /// Lógica interna para MeusVendedores.xaml
    /// </summary>
    public partial class MeusVendedores : Window
    {
        public MeusVendedores()
        {
            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }



        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalvar_Edicao_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtgMeusVendedores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnNovoVendedor_Click_1(object sender, RoutedEventArgs e)
        {
            CadastrarVendedor nova_tela = new CadastrarVendedor();
            nova_tela.Show();
        }
    }
}
