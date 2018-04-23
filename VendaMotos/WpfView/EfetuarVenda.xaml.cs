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
    /// Lógica interna para EfetuarVenda.xaml
    /// </summary>
    public partial class EfetuarVenda : Window
    {
        Contexto ctx = new Contexto();

        public EfetuarVenda()
        {
            InitializeComponent();
            cbxCliente.ItemsSource = ctx.tblClientes.ToList();          
            cbxVendedor.ItemsSource = ctx.tblVendedores.ToList();
            cbxMoto.ItemsSource = ctx.tblMotos.ToList();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GerarVenda();
            }
            catch
            {
                MessageBox.Show("Você precisa preencher todos os campos primeiro!!");
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            Limpar();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //_____________________________________________
        //Métodos: Vendas
        //_____________________________________________
        public void GerarVenda()
        {
            Venda NovaVenda = new Venda();

            NovaVenda.DataVenda = DateTime.Today;
            NovaVenda.ClienteID = ((Cliente)cbxCliente.SelectedItem).PessoaID;
            NovaVenda.VendedorID = ((Vendedor)cbxVendedor.SelectedItem).PessoaID;
            NovaVenda.MotoID = ((Moto)cbxMoto.SelectedItem).MotoID;
            

            VendaController vc = new VendaController();
            vc.SalvaVenda(NovaVenda);
            MessageBox.Show("Venda realizada com sucesso!");
            Limpar();
        }

        public void Limpar()
        {
            cbxCliente.Text = "";
            cbxMoto.Text = "";
            cbxVendedor.Text = "";
        }
    }
}
