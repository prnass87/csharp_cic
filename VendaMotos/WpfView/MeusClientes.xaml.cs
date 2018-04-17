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
            try
            {
                Tab_Editar.IsSelected = true;

                txtPesquisaNome.Text = selecionado.Nome;
                txtPesquisaCPF.Text = selecionado.Cpf;
                txtPesquisaRua.Text = selecionado._Endereco.Rua;
                txtPesquisaComplemento.Text = selecionado._Endereco.Complemento;
                txtPesquisaNumero.Text = selecionado._Endereco.Numero.ToString();
            }
            catch
            {
                MessageBox.Show("Nenhum carrinho selecionado!!");
            }
            txtExcluir.Text = "";
            txtID.Text = "";
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            dtgMeusClientes.ItemsSource = ctx.tblClientes.ToList();
            txtID.Text = "";
            txtExcluir.Text = "";
            lblQuantidadeClientes.Content = ctx.tblClientes.Count();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            List<Cliente> selecao = new List<Cliente>();

            try
            {
                selecionado = (from c in ctx.tblClientes
                               where c.Nome.Contains(txtExcluir.Text)
                               select c).First();
                if (selecionado == null)
                {
                    return;
                } else
                {
                    txtID.Text = selecionado.PessoaID.ToString();
                    selecao.Add(selecionado);
                }
            }
            catch
            {
                MessageBox.Show("Carrinho não encontrado!!");
            }

            dtgMeusClientes.ItemsSource = selecao.ToList();
            txtExcluir.Text = "";
            txtID.Text = "";
        }

        private void btnSalvar_Edicao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selecionado.Nome = txtPesquisaNome.Text;
                selecionado.Cpf = txtPesquisaCPF.Text;
                selecionado._Endereco.Rua = txtPesquisaRua.Text;
                selecionado._Endereco.Complemento = txtPesquisaComplemento.Text;
                selecionado._Endereco.Numero = int.Parse(txtPesquisaNumero.Text);

                ctx.SaveChanges();
                dtgMeusClientes.ItemsSource = ctx.tblClientes.ToList();
                lblQuantidadeClientes.Content = ctx.tblClientes.Count();

                txtExcluir.Text = "";
                txtID.Text = "";

                txtPesquisaNome.Text = "";
                txtPesquisaCPF.Text = "";
                txtPesquisaRua.Text = "";
                txtPesquisaComplemento.Text = "";
                txtPesquisaNumero.Text = "";

            }
            catch
            {
                MessageBox.Show("Selecione um carrinho para editar!!");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtExcluir.Text = "";
            txtID.Text = "";

            txtPesquisaNome.Text = "";
            txtPesquisaCPF.Text = "";
            txtPesquisaRua.Text = "";
            txtPesquisaComplemento.Text = "";
            txtPesquisaNumero.Text = "";

            Tab_Editar.IsSelected = true;
        }
    }
}
