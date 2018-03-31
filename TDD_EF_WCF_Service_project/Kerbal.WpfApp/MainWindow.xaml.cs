using Kerbal.Contracts;
using Kerbal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace Kerbal.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startBtn.IsEnabled = true;
            stopBtn.IsEnabled = false;

            this.Title = string.Format("Current UI thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        ServiceHost _kerbalService = null;

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            _kerbalService = new ServiceHost(typeof(KerbalManager));
            _kerbalService.Open();

            startBtn.IsEnabled = false;
            stopBtn.IsEnabled = true;
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            _kerbalService.Close();

            startBtn.IsEnabled = true;
            stopBtn.IsEnabled = false;
        }
    }
}
