using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TNS.Front_end.CRM;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;


namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для EquipmentMagisralNetworks.xaml
    /// </summary>
    public partial class EquipmentMagisralNetworks : Page
    {
        List<GetAllEquipments_GET> _equipment;

        public EquipmentMagisralNetworks()
        {
            InitializeComponent();

            _equipment = GetEquipment();

            membersDataGrid.ItemsSource = _equipment;

        }

        private static List<GetAllEquipments_GET> GetEquipment()
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = httpClient.GetAsync("https://localhost:7110/equipment/getAllEquipment").Result;
                response.EnsureSuccessStatusCode();

                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var subscribers = JsonSerializer.Deserialize<List<GetAllEquipments_GET>>(jsonResponse);

                return subscribers;
            }
            catch (HttpRequestException ex)
            {
                // Обработка ошибок при запросе к API
                MessageBox.Show($"Ошибка при получении подписчиков: {ex.Message}");
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
            AddEquipmentMagisralNetworks addWindow = new AddEquipmentMagisralNetworks();
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
            var subscriber = ellipse.DataContext as GetAllEquipments_GET;
            OpenEquipmentMagisralNetworks openWindow  = new OpenEquipmentMagisralNetworks(this, subscriber);
            openWindow.Show();
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllEquipments_GET;
            EditEquipmentMagisralNetworks editWindow = new EditEquipmentMagisralNetworks(this, subscriber);
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

        private void AttenuationCoefficientBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DTTBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddressBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllEquipments_GET;
            string messageBox = $"Вы точно хотите удалить оборудование \"{subscriber.Name}\"?";
        }
    }
}
