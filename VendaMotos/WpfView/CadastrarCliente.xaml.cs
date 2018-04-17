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
    /// Lógica interna para CadastrarCliente.xaml
    /// </summary>
    public partial class CadastrarCliente : Window
    {
        
        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CadastroCliente();
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
        //Métodos: Cliente
        //_____________________________________________
        public void CadastroCliente()
        {
            Cliente NovoCliente = new Cliente();

            NovoCliente.Nome = txtNome.Text;
            NovoCliente.Cpf = txtCPF.Text;

            NovoCliente.EnderecoID = CadastroEndereco().EnderecoID;

            ClienteController cc = new ClienteController();
            cc.SalvarCliente(NovoCliente);

            txtNome.Text = "";
            txtCPF.Text = "";
            txtRua.Text = "";
            txtComplemento.Text = "";
            txtNumero.Text = "";
        }


        //_____________________________________________
        //Métodos: Endereco
        //_____________________________________________
        public Endereco CadastroEndereco()
        {
            Endereco end = new Endereco();

            end.Rua = txtRua.Text;
            end.Complemento = txtComplemento.Text;
            end.Numero = int.Parse(txtNumero.Text);

            EnderecoController ec = new EnderecoController();
            ec.SalvarEndereco(end);
            return end;
        }

        //_____________________________________________
        //Métodos: Limpar
        //_____________________________________________
        public void Limpar()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRua.Text = "";
            txtComplemento.Text = "";
            txtNumero.Text = "";
        }
    }
}
