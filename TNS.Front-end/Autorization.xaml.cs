using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TNS.Front_end.Employee.MODELS;

namespace TNS.Front_end;

public partial class Autorization : Window
{
    public Autorization()
    {
        InitializeComponent();
    }
    private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)       => Close();                             //  закрыть окно
    private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)   => WindowState = WindowState.Minimized; //  свернуть окно    
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

                if (response.Result.StatusCode == HttpStatusCode.OK)
                {
                    var jsonResponse = response.Result.Content.ReadAsStringAsync().Result;
                    employee = JsonSerializer.Deserialize<GetAllEmployees_GET>(jsonResponse);

                    MainWindow mainWindow = new(employee);
                    mainWindow.Show();
                    Close();
                }
                else 
                {
                    var dialog = new MessageWindow("Неправильный логин или пароль.");
                }
            }
            catch (HttpRequestException)
            {
                var dialog = new MessageWindow($"Ошибка на сервере при попытке авторизации.");
                return;
            }
            catch (JsonException)
            {
                var dialog = new MessageWindow($"Ошибка при попытке прочитать JSON.");
                return;
            }
        }
        else 
        {
            var dialog = new MessageWindow("Пожалуйста, введите логин и пароль.");
        }
    }

    private void Number_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        textBox.Text = Regex.Replace(textBox.Text, @"[^\d\+\-]", "");
        textBox.SelectionStart = textBox.Text.Length;
    }
}