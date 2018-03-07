using Client.VelibServiceReference;
using System.Collections.Generic;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            VelibInfosClient velibInfos = new VelibInfosClient();
            listBoxContracts.ItemsSource = velibInfos.GetContracts();
        }
    }
}
