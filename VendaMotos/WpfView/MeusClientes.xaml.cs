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
    /// Lógica interna para MeusClientes.xaml
    /// </summary>
    public partial class MeusClientes : Window
    {
        Contexto ctx = new Contexto();
        Cliente selecionado = null;

        public MeusClientes()
        {
            InitializeComponent();
            try
            {
                dtgMeusClientes.ItemsSource = ctx.tblClientes.ToList();
            }
            catch (Exception)
            {
                
            }
            lblQuantidadeClientes.Content = ctx.tblClientes.Count();
        }

        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente nova_tela = new CadastrarCliente();
            nova_tela.Show();
        }


        private void dtgMeusClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                selecionado = (Cliente)dtgMeusClientes.SelectedItem;
                txtExcluir.Text = selecionado.Nome;
                txtID.Text = selecionado.PessoaID.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID = selecionado.PessoaID;
                selecionado = (from c in ctx.tblClientes
                               where c.PessoaID == ID
                               select c).First();
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
                ctx.tblClientes.Remove(selecionado);
                ctx.SaveChanges();
                txtID.Text = "";
                txtExcluir.Text = "";
                dtgMeusClientes.ItemsSource = ctx.tblClientes.ToList();
                lblQuantidadeClientes.Content = ctx.tblClientes.Count();
            }
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
