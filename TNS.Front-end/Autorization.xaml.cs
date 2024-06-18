using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text.Json;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TNS.Front_end.Employee.MODELS;

namespace TNS.Front_end;

/// <summary>
/// Логика взаимодействия для Autorization.xaml
/// </summary>
public partial class Autorization : Window
{
    public Autorization()
    {
        InitializeComponent();

        //code.Visibility = Visibility.Hidden;
        //textCode.Visibility = Visibility.Hidden;
        //refreshButton.Visibility = Visibility.Hidden;

    }
    private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)       => Close();                             //  закрыть окно
    private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)   => WindowState = WindowState.Minimized; //  свернуть окно
    private void Image_MouseDown_Del(object sender, MouseButtonEventArgs e)         => code.Clear();                        //  обновление одноразового кода?
    
    /// <summary>
    /// Логика авторизации и аутентификации
    /// </summary>
    private void Authorization_Click(object sender, RoutedEventArgs e)
    {
        GetAllEmployees_GET employee;
        if (!string.IsNullOrWhiteSpace(number.Text) || !string.IsNullOrWhiteSpace(password.Text))
        {
            Login_POST login = new(number.Text, password.Text);

            using var httpClient = new HttpClient();
            try
            {
                var response = httpClient.PostAsJsonAsync($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/employee/login", login);

                var jsonResponse = response.Result.Content.ReadAsStringAsync().Result;
                employee = JsonSerializer.Deserialize<GetAllEmployees_GET>(jsonResponse);
            }
            catch (HttpRequestException ex)
            {
                var dialog = new MessageWindow($"Ошибка при добавлении данных: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                var dialog = new MessageWindow($"JSON-deserailization error: {ex.Message}");
                throw;
            }

            MainWindow mainWindow = new(employee);
            mainWindow.Show();
            Close();
        }
        else 
        {
            var dialog = new MessageWindow("Пожалуйста, введите логин и пароль.");
        }
    }
}