﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TumleTjek.View
{
    /// <summary>
    /// Interaction logic for MedarbejderWindow.xaml
    /// </summary>
    public partial class MedarbejderWindow : Window
    {
        public MedarbejderWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_StatusFra(object sender, RoutedEventArgs e)
        {
            // Navigate to FravaerPage.xaml
            var fravaerPage = new FravaerPage();
            this.Content = fravaerPage;
        }
    }
}
