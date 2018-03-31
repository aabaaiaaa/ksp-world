using Kerbal.Proxy;
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
            var kerbalsNotOnMission = kerbalProxy.GetKerbalInfo(false);

            kerbalListBox.ItemsSource = kerbalsNotOnMission.Select(k => string.Format("{0}, {1}", k.Name, k.LastMission));
            kerbalListLabel.ContentStringFormat = "Number of Kerbals: {0}";
            kerbalListLabel.Content = kerbalsNotOnMission.Count();
            kerbalProxy.Close();
        }

        private void AddKerbals_Click(object sender, RoutedEventArgs e)
        {
            var kerbalProxy = new KerbalProxy();

            var kerbalName = kerbalNameTxt.Text;
            var missionRef = missionRefTxt.Text;
            var targetPlanet = targetPlanetTxt.Text;

            kerbalProxy.AddKerbalInfo(kerbalName, missionRef, targetPlanet);

            kerbalProxy.Close();
        }

        private void RemoveKerbal_Click(object sender, RoutedEventArgs e)
        {
            var kerbalProxy = new KerbalProxy();

            var kerbalName = removeKerbalNameTxt.Text;

            kerbalProxy.RemoveKerbalInfo(kerbalName);

            kerbalProxy.Close();
        }
    }
}
