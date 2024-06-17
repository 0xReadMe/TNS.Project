using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TNS.Front_end.CRM.MODELS;
using TNS.Front_end.SUBSCRIBERS.MODELS;
namespace TNS.Front_end.CRM;

/// <summary>
/// Логика взаимодействия для CRM.xaml
/// </summary>
public partial class CRM_Page : Page
{
    //List<string> services = [];
    
    //List<CRM_request> membersCopy;
    //List<CRM_request> membersChanged;
    List<CRM_viewmodel> CRM;

    public CRM_Page()
    {
        InitializeComponent();
        //membersCopy = new(members);
        //membersDataGrid.ItemsSource = members;

        CRM = GetCRM();

        membersDataGrid.ItemsSource = CRM;
    }

    private static List<CRM_viewmodel> GetCRM()
    {
        using var httpClient = new HttpClient();
        try
        {
            var response = httpClient.GetAsync("https://localhost:7110/CRM/getAll").Result;
            response.EnsureSuccessStatusCode();

            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            var subscribers = JsonSerializer.Deserialize<List<GetAllCRM_GET>>(jsonResponse);
            List<CRM_viewmodel> crmList = [];
            foreach (var item in subscribers)
            {
                CRM_viewmodel model = new()
                {
                    Id = item.Id,
                    CreationDate = item.CreationDate,
                    ClosingDate = item.ClosingDate,
                    Status = item.Status,
                    TypeOfProblem = item.TypeOfProblem,
                    ProblemDescription = item.ProblemDescription
                };

                response = httpClient.GetAsync($"https://localhost:7110/subscriber/get/{item.SubscriberId}").Result;
                response.EnsureSuccessStatusCode();
                jsonResponse = response.Content.ReadAsStringAsync().Result;
                var sub = JsonSerializer.Deserialize<GetSubscriber_GET>(jsonResponse);

                model.PersonalBill = sub.PersonalBill.ToString();
                model.SubscriberNumber = sub.SubscriberNumber;
                model.TypeOfEquipment = sub.TypeOfEquipment;

                //TODO: service parse from api

                crmList.Add(model);
            }

            return crmList;
        }
        catch (HttpRequestException ex)
        {
            // Обработка ошибок при запросе к API
            MessageBox.Show($"Ошибка при получении CRM-заявок: {ex.Message}");
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

    private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void StatusBtn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void TypeEquipmentBtn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void AddButton(object sender, RoutedEventArgs e)
    {
        AddCRM addCRM = new();
        addCRM.Show();
    }

    private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var ellipse = sender as Ellipse;
        var subscriber = ellipse.DataContext as CRM_viewmodel;
        EditCRM editCRM = new(this, subscriber);
        editCRM.Show();
    }

    private void Open_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var ellipse = sender as Ellipse;
        var subscriber = ellipse.DataContext as CRM_viewmodel;
        OpenCRM openCRM = new(this, subscriber);
        openCRM.Show();
    }

    private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
    {

    }

    private void ServicesBtn_Click(object sender, RoutedEventArgs e)
    {

    }

    private void testEquipmentButton_Click(object sender, RoutedEventArgs e)
    {
        TestEquipment testEquipment = new TestEquipment();
        testEquipment.Show();
    }

    private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }
}
