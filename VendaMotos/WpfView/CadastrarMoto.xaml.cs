﻿using System;
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

        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
