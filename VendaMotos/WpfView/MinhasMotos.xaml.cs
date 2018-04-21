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
    /// Lógica interna para MinhasMotos.xaml
    /// </summary>
    public partial class MinhasMotos : Window
    {
        Contexto ctx = new Contexto();
        Moto selecionado = null;

        public MinhasMotos()
        {
            InitializeComponent();
            try
            {
                dtgMinhasMotos.ItemsSource = ctx.tblMotos.ToList();
            }
            catch (Exception)
            {

            }
            lblQuantidadeMotos.Content = ctx.tblMotos.Count();
        }

        private void btnNovaMoto_Click(object sender, RoutedEventArgs e)
        {
            CadastrarMoto nova_tela = new CadastrarMoto();
            nova_tela.Show();
        }

        private void dtgMinhasMotos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dtgAtualiza();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ExcluirMoto();
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
            BuscaMoto();
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
        //Métodos: Moto
        //_____________________________________________

        public void dtgAtualiza()
        {
            try
            {
                selecionado = (Moto)dtgMinhasMotos.SelectedItem;
                txtExcluir.Text = selecionado.Modelo;
                txtID.Text = selecionado.MotoID.ToString();
            }
            catch (Exception)
            {

            }
        }

        public void SalvaEdicao()
        {
            MotoController mc = new MotoController();
            try
            {
                selecionado.Marca  = txtMotoMarca.Text;
                selecionado.Modelo = txtMotoModelo.Text;
                selecionado.Cilindrada = txtMotoCilindrada.Text;
                selecionado.Ano = txtMotoAnoFabric.Text;
                selecionado.Cor = txtMotoCor.Text;
                selecionado.Placa = txtMotoPlaca.Text;
                selecionado.Valor = double.Parse(txtMotoValor.Text);
                selecionado.Status = txtMotoStatus.Text;

                mc.EditarMoto(selecionado.MotoID, selecionado);

                dtgMinhasMotos.ItemsSource = ctx.tblMotos.ToList();
                lblQuantidadeMotos.Content = ctx.tblMotos.Count();

                CancelarEdit();
            }
            catch
            {
                MessageBox.Show("Selecione uma moto para editar!!");
            }

        }

        public void ExcluirMoto()
        {
            MotoController mc = new MotoController();

            try
            {

                selecionado = mc.PesquisarPorID(selecionado.MotoID);
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
                mc.ExcluirMoto(selecionado.MotoID);

                txtID.Text = "";
                txtExcluir.Text = "";
                dtgMinhasMotos.ItemsSource = ctx.tblMotos.ToList();
                lblQuantidadeMotos.Content = ctx.tblMotos.Count();
            }
        }

        public void BuscaMoto()
        {
            List<Moto> selecao = new List<Moto>();

            try
            {
                MotoController mc = new MotoController();
                selecionado = mc.PesquisarPorModelo(txtExcluir.Text);

                if (selecionado == null)
                {
                    return;
                }
                else
                {
                    txtID.Text = selecionado.MotoID.ToString();
                    selecao.Add(selecionado);
                }
            }
            catch
            {
                MessageBox.Show("Moto não encontrada!!");
            }

            dtgMinhasMotos.ItemsSource = selecao.ToList();
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

                txtMotoMarca.Text = selecionado.Marca;
                txtMotoModelo.Text = selecionado.Modelo;
                txtMotoCilindrada.Text = selecionado.Cilindrada;
                txtMotoAnoFabric.Text = selecionado.Ano;
                txtMotoCor.Text = selecionado.Cor;
                txtMotoPlaca.Text = selecionado.Placa;
                txtMotoValor.Text = (selecionado.Valor).ToString();
                txtMotoStatus.Text = selecionado.Status;
            }
            catch
            {
                MessageBox.Show("Nenhuma moto selecionada!!");
            }

        }

        public void AtualizarTela()
        {
            dtgMinhasMotos.ItemsSource = ctx.tblMotos.ToList();
            txtID.Text = "";
            txtExcluir.Text = "";
            lblQuantidadeMotos.Content = ctx.tblMotos.Count();
        }

        public void CancelarEdit()
        {
            txtExcluir.Text = "";
            txtID.Text = "";


            txtMotoMarca.Text = "";
            txtMotoModelo.Text = "";
            txtMotoCilindrada.Text = "";
            txtMotoAnoFabric.Text = "";
            txtMotoCor.Text = "";
            txtMotoPlaca.Text = "";
            txtMotoValor.Text = "";
            txtMotoStatus.Text = "";

            MessageBox.Show("Retornando a lista de motos");

            Tab_Lista.IsSelected = true;
        }

    }
}
