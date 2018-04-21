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
    /// Lógica interna para MeusVendedores.xaml
    /// </summary>
    public partial class MeusVendedores : Window
    {
        Contexto ctx = new Contexto();
        Vendedor selecionado = null;

        public MeusVendedores()
        {
            InitializeComponent();
            try
            {
                dtgMeusVendedores.ItemsSource = ctx.tblVendedores.ToList();
            }
            catch (Exception)
            {
                
            }
            lblQuantidadeVendedores.Content = ctx.tblVendedores.Count();
        }

        private void btnNovoVendedor_Click_1(object sender, RoutedEventArgs e)
        {
            CadastrarVendedor nova_tela = new CadastrarVendedor();
            nova_tela.Show();
        }

        private void dtgMeusVendedores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dtgAtualiza();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ExcluirVendedor();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            TabEditar();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarTela();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BuscaVendedor();
        }

        private void btnSalvar_Edicao_Click(object sender, RoutedEventArgs e)
        {
            SalvaEdicao();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            CancelarEdit();
        }



        //_____________________________________________
        //Métodos: Vendedor
        //_____________________________________________

        public void dtgAtualiza()
        {
            try
            {
                selecionado = (Vendedor)dtgMeusVendedores.SelectedItem;
                txtExcluir.Text = selecionado.Nome;
                txtID.Text = selecionado.PessoaID.ToString();
            }
            catch (Exception)
            {

            }
        }

        public void SalvaEdicao()
        {
            VendedorController vc = new VendedorController();
            try
            {
                selecionado.Nome = txtPesquisaNome.Text;
                selecionado.Cpf = txtPesquisaCPF.Text;
                selecionado._Endereco.Rua = txtPesquisaRua.Text;
                selecionado._Endereco.Complemento = txtPesquisaComplemento.Text;
                selecionado._Endereco.Numero = int.Parse(txtPesquisaNumero.Text);

                vc.EditarVendedor(selecionado.PessoaID, selecionado);

                dtgMeusVendedores.ItemsSource = ctx.tblVendedores.ToList();
                lblQuantidadeVendedores.Content = ctx.tblVendedores.Count();

                CancelarEdit();
            }
            catch
            {
                MessageBox.Show("Selecione um vendedor para editar!!");
            }

        }

        public void ExcluirVendedor()
        {
            VendedorController vc = new VendedorController();

            try
            {

                selecionado = vc.PesquisarPorID(selecionado.PessoaID);
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
                vc.ExcluirVendedor(selecionado.PessoaID);

                txtID.Text = "";
                txtExcluir.Text = "";
                dtgMeusVendedores.ItemsSource = ctx.tblVendedores.ToList();
                lblQuantidadeVendedores.Content = ctx.tblVendedores.Count();
            }
        }

        public void BuscaVendedor()
        {
            List<Vendedor> selecao = new List<Vendedor>();

            try
            {
                VendedorController vc = new VendedorController();
                selecionado = vc.PesquisarPorNome(txtExcluir.Text);

                if (selecionado == null)
                {
                    return;
                }
                else
                {
                    txtID.Text = selecionado.PessoaID.ToString();
                    selecao.Add(selecionado);
                }
            }
            catch
            {
                MessageBox.Show("Vendedor não encontrado!!");
            }

            dtgMeusVendedores.ItemsSource = selecao.ToList();
            txtExcluir.Text = "";
            txtID.Text = "";
        }

        public void TabEditar()
        {
            try
            {
                txtExcluir.Text = "";
                txtID.Text = "";
                Tab_Editar.IsSelected = true;

                txtPesquisaNome.Text = selecionado.Nome;
                txtPesquisaCPF.Text = selecionado.Cpf;
                txtPesquisaRua.Text = selecionado._Endereco.Rua;
                txtPesquisaComplemento.Text = selecionado._Endereco.Complemento;
                txtPesquisaNumero.Text = selecionado._Endereco.Numero.ToString();
            }
            catch
            {
                MessageBox.Show("Nenhum vendedor selecionado!!");
            }

        }

        public void AtualizarTela()
        {
            dtgMeusVendedores.ItemsSource = ctx.tblVendedores.ToList();
            txtID.Text = "";
            txtExcluir.Text = "";
            lblQuantidadeVendedores.Content = ctx.tblVendedores.Count();
        }

        public void CancelarEdit()
        {
            txtExcluir.Text = "";
            txtID.Text = "";

            txtPesquisaNome.Text = "";
            txtPesquisaCPF.Text = "";
            txtPesquisaRua.Text = "";
            txtPesquisaComplemento.Text = "";
            txtPesquisaNumero.Text = "";

            MessageBox.Show("Retornando a lista de vendedores");

            Tab_Lista.IsSelected = true;
        }
    }
}
