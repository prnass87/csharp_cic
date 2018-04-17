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
            try
            {
                CadastroVendedor();
            }
            catch
            {
                MessageBox.Show("Voce precisa preencher  todos os campos primeiro");
            }

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            Limpar();
        }

        //________________________________________________________________
        //Metodos Vendedores
        //________________________________________________________________

        public void CadastroVendedor()
        {
            Vendedor NovoVendedor = new Vendedor();
            NovoVendedor.Nome = txtNome.Text;
            NovoVendedor.Cpf = txtCPF.Text;

            NovoVendedor.EnderecoID = CadastroEndereco().EnderecoID;

            VendedorController vc = new VendedorController();
            vc.SalvarVendedor(NovoVendedor);
            MessageBox.Show("Vendedor cadastrado com sucesso!");
            Limpar();
        }

        //________________________________________________________________
        //Metodos Endereco
        //________________________________________________________________

        public Endereco CadastroEndereco()
        {
            Endereco end = new Endereco();
            end.Rua = txtRua.Text;
            end.Complemento = txtComplemento.Text;
            end.Numero =  int.Parse(txtNumero.Text);

            EnderecoController ec = new EnderecoController();
            ec.SalvarEndereco(end);
            return end;
        }
        //________________________________________________________________
        //Metodos Limpar
        //________________________________________________________________

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
