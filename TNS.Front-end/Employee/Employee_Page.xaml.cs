using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TNS.Front_end.Employee.MODELS;

namespace TNS.Front_end.Employee
{
    /// <summary>
    /// Логика взаимодействия для Employee_Page.xaml
    /// </summary>
    public partial class Employee_Page : Page
    {
        List<GetAllEmployees_GET> _employee;

        public Employee_Page()
        {
            InitializeComponent();

            _employee = GetEmployee();
            membersDataGrid.ItemsSource = _employee;
        }

        private static List<GetAllEmployees_GET> GetEmployee()
        {
            using var httpClient = new HttpClient();
            try
            {
                var response = httpClient.GetAsync("https://localhost:7110/employee/getAll").Result;
                response.EnsureSuccessStatusCode();

                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var subscribers = JsonSerializer.Deserialize<List<GetAllEmployees_GET>>(jsonResponse);

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

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Open_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllEmployees_GET;
            OpenEmployee openEmployee = new OpenEmployee(this, subscriber);
            openEmployee.Show();
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllEmployees_GET;
            EditEmployee editEmployee = new EditEmployee(this, subscriber);
            editEmployee.Show();
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
        }

        private void PositionNameBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DateBirthBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmailBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FullNameBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
