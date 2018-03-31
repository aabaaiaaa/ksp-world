﻿using Kerbal.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kerbal.ClientWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = string.Format("Current thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        private void ListKerbals_Click(object sender, RoutedEventArgs e)
        {
            var kerbalProxy = new KerbalProxy();
            var kerbalsOnMission = kerbalProxy.GetKerbalInfo(true);

            kerbalListBox.ItemsSource = kerbalsOnMission;
            kerbalListLabel.ContentStringFormat = "Number of Kerbals: {0}";
            kerbalListLabel.Content = kerbalsOnMission.Count();
            kerbalProxy.Close();
        }

        private void AddKerbals_Click(object sender, RoutedEventArgs e)
        {
            var kerbalProxy = new KerbalProxy();

            var kerbalName = kerbalNameTxt.Text;
            var missionRef = missionRefTxt.Text;
            var targetPlanet = targetPlanetTxt.Text;

            kerbalProxy.Close();
        }
    }
}