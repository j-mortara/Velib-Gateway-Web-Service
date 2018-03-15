using Client.VelibServiceReference;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Client
{

    public partial class MainWindow : Window
    {
        private VelibInfosClient velibInfos;
        private string contractName;

        public MainWindow()
        {
            InitializeComponent();
            velibInfos = new VelibInfosClient();
            GetContracts();
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxContracts.SelectedItem != null)
            {
                contractName = listBoxContracts.SelectedItem.ToString();
                GetStations();
            }
        }

        private void selectStationButton_Click(object sender, RoutedEventArgs e)
        {
            if(listBoxStations.SelectedItem != null)
            {
                GetNumberOfBikes(contractName, listBoxStations.SelectedItem.ToString());
            }
        }

        private async void GetContracts()
        {
            listBoxContracts.ItemsSource = await velibInfos.GetContractsAsync();
        }

        private async void GetStations()
        {
            listBoxStations.ItemsSource = await velibInfos.GetStationsAsync(contractName);
        }

        private async void GetNumberOfBikes(string contract, string station)
        {
            textBox.Text = "Number of available bikes : " + await velibInfos.GetAvailableBikesAsync(contract, station);
        }
    }
}
