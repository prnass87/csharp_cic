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
    /// Lógica interna para MeusClientes.xaml
    /// </summary>
    public partial class MeusClientes : Window
    {
        public MeusClientes()
        {
            InitializeComponent();
        }

        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente nova_tela = new CadastrarCliente();
            nova_tela.Show();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtgMeusClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
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
    }
}
