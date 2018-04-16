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

        Contexto ctx = new Contexto();
        Cliente NovoCliente = null;

        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NovoCliente = new Cliente();
                NovoCliente.Nome = txtNome.Text;
                NovoCliente.Cpf = txtCPF.Text;
                NovoCliente._Endereco.Rua = txtRua.Text;
                NovoCliente._Endereco.Complemento = txtComplemento.Text;
                NovoCliente._Endereco.Numero = int.Parse(txtNumero.Text);

                ctx.tblClientes.Add(NovoCliente);
                ctx.SaveChanges();

                txtNome.Text = "";
                txtCPF.Text = "";
                txtRua.Text = "";
                txtComplemento.Text = "";
                txtNumero.Text = "";

            }
            catch
            {
                MessageBox.Show("Você precisa preencher todos os campos primeiro!!");
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRua.Text = "";
            txtComplemento.Text = "";
            txtNumero.Text = "";
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
