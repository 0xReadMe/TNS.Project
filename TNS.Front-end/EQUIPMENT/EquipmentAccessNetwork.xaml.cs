using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
using TNS.Front_end.CRM;
using TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для EquipmentAccessNetwork.xaml
    /// </summary>
    public partial class EquipmentAccessNetwork : Page
    {
        List<GetAllBaseStations_GET> _equipment;

        public EquipmentAccessNetwork()
        {
            InitializeComponent();
            _equipment = GetEquipment();

            membersDataGrid.ItemsSource = _equipment;
        }

        private static List<GetAllBaseStations_GET> GetEquipment()
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = httpClient.GetAsync("https://localhost:7110/equipment/getAllBaseStations").Result;
                response.EnsureSuccessStatusCode();

                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var subscribers = JsonSerializer.Deserialize<List<GetAllBaseStations_GET>>(jsonResponse);

                return subscribers;
            }
            catch (HttpRequestException ex)
            {
                // Обработка ошибок при запросе к API
                MessageBox.Show($"Ошибка при получении оборудования: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                // Обработка ошибок при десериализации JSON-ответа
                MessageBox.Show($"Ошибка при десериализации JSON-ответа: {ex.Message}");
                throw;
            }
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddEquipmentAccessNetwork addWindow = new();
            addWindow.Show();
        }

        private void testEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            TestEquipment testWindow = new TestEquipment();
            testWindow.Show();
        }

        private void Open_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllBaseStations_GET;
            OpenEquipmentAccessNetwork openWindow = new(this, subscriber);
            openWindow.Show();
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllBaseStations_GET;
            EditEquipmentAccessNetwork editWindow = new EditEquipmentAccessNetwork(this, subscriber);
            editWindow.Show();
        }

        private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FrequencyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TypeAntennaBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CommunicationProtocolBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllBaseStations_GET;
            string messageBox = $"Вы точно хотите удалить оборудование \"{subscriber.BaseStationName}\"?";
        }

    }
}
