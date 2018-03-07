using Client.VelibServiceReference;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VelibInfosClient velibInfos;
        private string contractName;

        public MainWindow()
        {
            InitializeComponent();
            velibInfos = new VelibInfosClient();
            listBoxContracts.ItemsSource = velibInfos.GetContracts();
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            contractName = listBoxContracts.SelectedItem.ToString();
            listBoxStations.ItemsSource = velibInfos.GetStations(contractName);
        }

        private void selectStationButton_Click(object sender, RoutedEventArgs e)
        {
            string stationName = listBoxStations.SelectedItem.ToString();
            textBox.Text = "Number of available bikes : " + velibInfos.GetAvailableBikes(contractName, stationName);
        }
    }
}
