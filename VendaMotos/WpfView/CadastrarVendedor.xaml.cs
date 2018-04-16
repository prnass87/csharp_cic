using System;
using Controllers;
using Models;
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
using Models.DAL;

namespace WpfView
{
    /// <summary>
    /// Lógica interna para CadastrarVendedor.xaml
    /// </summary>
    public partial class CadastrarVendedor : Window
    {

        Contexto ctx = new Contexto();

        public CadastrarVendedor()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRua.Text = "";
            txtComplemento.Text = "";
            txtNumero.Text = "";
        }
    }
}
