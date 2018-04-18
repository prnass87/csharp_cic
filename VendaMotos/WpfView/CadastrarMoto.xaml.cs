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
    /// Lógica interna para CadastrarMoto.xaml
    /// </summary>
    public partial class CadastrarMoto : Window
    {
        public CadastrarMoto()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CadastroMoto();
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
        //Métodos: Moto
        //_____________________________________________
        public void CadastroMoto()
        {
            Moto NovaMoto = new Moto();

            NovaMoto.Marca = txtMarca.Text;
            NovaMoto.Modelo = txtModelo.Text;
            NovaMoto.Cilindrada = txtCilindrada.Text;
            NovaMoto.Ano = txtAnoFabric.Text;
            NovaMoto.Cor = txtCor.Text;
            NovaMoto.Placa = txtPlaca.Text;
            NovaMoto.Valor = double.Parse(txtValor.Text);
            NovaMoto.Status = txtStatus.Text;

            MotoController mc = new MotoController();
            mc.SalvarMoto(NovaMoto);
            MessageBox.Show("Moto cadastrada com sucesso!");
            Limpar();
        }

        //_____________________________________________
        //Métodos: Limpar
        //_____________________________________________
        public void Limpar()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtCilindrada.Text = "";
            txtAnoFabric.Text = "";
            txtCor.Text = "";
            txtPlaca.Text = "";
            txtValor.Text = "";
            txtStatus.Text = "";
        }
    }
}
