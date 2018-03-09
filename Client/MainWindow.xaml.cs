using Client.VelibServiceReference;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    
    public partial class MainWindow : Window
    {
        // List containing the previously queried stations (i.e. the cache)
        private static List<Station> stations = new List<Station>();

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
            if (listBoxContracts.SelectedItem != null)
            {
                contractName = listBoxContracts.SelectedItem.ToString();
                listBoxStations.ItemsSource = velibInfos.GetStations(contractName);
            }
        }

        private void selectStationButton_Click(object sender, RoutedEventArgs e)
        {
            if(listBoxStations.SelectedItem != null)
            {
                string stationName = listBoxStations.SelectedItem.ToString();
                Station selectedStation = new Station(contractName, stationName);
                Station stationInList = stations.Find(s => s.Equals(selectedStation));
                // If the station has never been queried or its information is outdated, an update is needed.
                // Otherwise, there is no need to fetch the information. This limits the number of calls to the API.
                if (stationInList == null || stationInList.IsInformationOutdated())
                {
                    // Gets the actual value from the server
                    selectedStation.nbAvailableBikes = velibInfos.GetAvailableBikes(contractName, stationName);
                    // Removes the already present object representing the station if it exists in the cache.
                    stations.Remove(stationInList);
                    // Adds the newly created object.
                    stations.Add(selectedStation);
                }
                // stations.Find() can't be null, as there is necessarily an item matching the condition in the cache.
                // Indeed, if the element was not already present in the cache, it has been added in the previous condition.
                textBox.Text = "Number of available bikes : " + stations.Find(s => s.Equals(selectedStation)).nbAvailableBikes;
            }
        }
    }
}
