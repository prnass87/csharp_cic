﻿using Controllers;
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

        //Inicializa e carrega a tela;
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

        //Cadastra o cliente
        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente nova_tela = new CadastrarCliente();
            nova_tela.Show();
        }

        //Pega o cliente selecionado no datagrid
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

        //Excluir cliente (ERRO)
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClienteController cc = new ClienteController();
                selecionado = cc.PesquisarPorID(selecionado.PessoaID);
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
                ExcluirCliente();
            }
        }
        
        //Altera para a tela de edição
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TabEditar();
            }
            catch
            {
                MessageBox.Show("Nenhum carrinho selecionado!!");
            }
            txtExcluir.Text = "";
            txtID.Text = "";
        }

        //Atualiza grid
        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarTela();
        }

        //Pesquisando clientes por nome.
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            List<Cliente> selecao = new List<Cliente>();

            try
            {
                ClienteController cc = new ClienteController();
                selecionado = cc.PesquisarPorNome(txtExcluir.Text);

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
                SalvaEdicao();
            }
            catch
            {
                MessageBox.Show("Selecione um carrinho para editar!!");
            }
        }

        //Botão cancelar na área de edição
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            CancelarEdit();
        }


        //_____________________________________________
        //Métodos: Cliente
        //_____________________________________________
        public void SalvaEdicao()
        {
            selecionado.Nome = txtPesquisaNome.Text;
            selecionado.Cpf = txtPesquisaCPF.Text;
            selecionado._Endereco.Rua = txtPesquisaRua.Text;
            selecionado._Endereco.Complemento = txtPesquisaComplemento.Text;
            selecionado._Endereco.Numero = int.Parse(txtPesquisaNumero.Text);
                        
            ctx.SaveChanges();
            dtgMeusClientes.ItemsSource = ctx.tblClientes.ToList();
            lblQuantidadeClientes.Content = ctx.tblClientes.Count();

            CancelarEdit();
        }

        public void ExcluirCliente()
        {
            ClienteController cc = new ClienteController();
            cc.ExcluirCliente(selecionado.PessoaID);

            txtID.Text = "";
            txtExcluir.Text = "";
            dtgMeusClientes.ItemsSource = ctx.tblClientes.ToList();
            lblQuantidadeClientes.Content = ctx.tblClientes.Count();
        }

        public void TabEditar()
        {
            Tab_Editar.IsSelected = true;

            txtPesquisaNome.Text = selecionado.Nome;
            txtPesquisaCPF.Text = selecionado.Cpf;
            txtPesquisaRua.Text = selecionado._Endereco.Rua;
            txtPesquisaComplemento.Text = selecionado._Endereco.Complemento;
            txtPesquisaNumero.Text = selecionado._Endereco.Numero.ToString();
        }

        public void AtualizarTela()
        {
            dtgMeusClientes.ItemsSource = ctx.tblClientes.ToList();
            txtID.Text = "";
            txtExcluir.Text = "";
            lblQuantidadeClientes.Content = ctx.tblClientes.Count();
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

            MessageBox.Show("Retornando a lista de clientes");

            Tab_Lista.IsSelected = true;
        }
    }
}
