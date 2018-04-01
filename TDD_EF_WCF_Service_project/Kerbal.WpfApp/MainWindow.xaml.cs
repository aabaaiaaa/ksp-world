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

            _mainWindow = this;
            _syncContext = SynchronizationContext.Current;

            startBtn.IsEnabled = true;
            stopBtn.IsEnabled = false;

            this.Title = string.Format("Current UI thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public static MainWindow _mainWindow = null;

        ServiceHost _kerbalService = null;
        ServiceHost _messageService = null;
        SynchronizationContext _syncContext = null;

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            _kerbalService = new ServiceHost(typeof(KerbalManager));
            _messageService = new ServiceHost(typeof(MessageManager));
            _kerbalService.Open();
            _messageService.Open();

            startBtn.IsEnabled = false;
            stopBtn.IsEnabled = true;
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            _kerbalService.Close();
            _messageService.Close();

            startBtn.IsEnabled = true;
            stopBtn.IsEnabled = false;
        }

        public void ShowMessage(string message)
        {
            var windowThread = Thread.CurrentThread.ManagedThreadId.ToString();
            SendOrPostCallback cb = new SendOrPostCallback(args => {
                var callbackThread = Thread.CurrentThread.ManagedThreadId.ToString();
                textBoxLog.AppendText(string.Format("Marhsalling from thread: {0} to {1}, message: {2}", callbackThread, windowThread, message) + Environment.NewLine);
            });
            _syncContext.Send(cb, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(() => {
                ChannelFactory<IMessageService> channelFactory = new ChannelFactory<IMessageService>("");
                var proxy = channelFactory.CreateChannel();
                proxy.ShowMessage("In-process message");
                channelFactory.Close();
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
