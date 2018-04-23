using Controllers;
using Models;
using Models.DAL;
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

        Contexto ctx = new Contexto();
        Venda selecionado = null;

        public MinhasVendas()
        {
            InitializeComponent();
            try
            {
                dtgMinhasVendas.ItemsSource = ctx.tblVendas.ToList();
            }
            catch (Exception)
            {

            }
            lblQuantidadeVendas.Content = ctx.tblVendas.Count();

        }

        private void btnNovaVenda_Click(object sender, RoutedEventArgs e)
        {
            EfetuarVenda nova_tela = new EfetuarVenda();
            nova_tela.Show();
        }

        private void dtgMinhasVendas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dtgAtualiza();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarTela();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ExcluirVenda();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscaCliente();
        }

        //_____________________________________________
        //Métodos: Vendas
        //_____________________________________________

        public void dtgAtualiza()
        {
            try
            {
                selecionado = (Venda)dtgMinhasVendas.SelectedItem;
                txtExcluir.Text = selecionado.VendaID.ToString();
                txtID.Text = selecionado.VendaID.ToString();
            }
            catch (Exception)
            {

            }
        }

        public void ExcluirVenda()
        {
            VendaController vc = new VendaController();

            try
            {

                selecionado = vc.PesquisarPorID(selecionado.VendaID);
            }
            catch (Exception)
            {
                MessageBox.Show("Selecione um item para excluir!!");
            }

            if (selecionado == null)
            {
                return;
            }
            else
            {
                vc.ExcluirVenda(selecionado.VendaID);

                txtID.Text = "";
                txtExcluir.Text = "";
                dtgMinhasVendas.ItemsSource = ctx.tblVendas.ToList();
                lblQuantidadeVendas.Content = ctx.tblVendas.Count();
            }
        }

        public void BuscaCliente()
        {
            List<Venda> selecao = new List<Venda>();

            try
            {
                VendaController vc = new VendaController();
                selecionado = vc.PesquisarPorID(selecionado.VendaID);

                if (selecionado == null)
                {
                    return;
                }
                else
                {
                    txtID.Text = selecionado.VendaID.ToString();
                    selecao.Add(selecionado);
                }
            }
            catch
            {
                MessageBox.Show("Venda não encontrada!!");
            }

            dtgMinhasVendas.ItemsSource = selecao.ToList();
            txtExcluir.Text = "";
            txtID.Text = "";
        }

        public void AtualizarTela()
        {
            dtgMinhasVendas.ItemsSource = ctx.tblVendas.ToList();
            txtID.Text = "";
            txtExcluir.Text = "";
            lblQuantidadeVendas.Content = ctx.tblVendas.Count();
        }
    }
}
