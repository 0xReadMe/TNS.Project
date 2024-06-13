using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TNS.Front_end.SUBSCRIBERS;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end;

/// <summary>
/// Логика взаимодействия для MainFrame.xaml
/// </summary>
public partial class Subscribers : Page
{
    public AddUser AboutWindow;
    bool servicesPressed = false;
    string contentBtn;

    readonly List<string> services = 
        [
            "Интернет",
            "Мобильная связь",
            "Телевидение",
            "Видеонаблюдение"
        ];

    List<GetSubscriber_GET> subscribers;


    public Subscribers()
    {
        InitializeComponent();
        subscribers = GetSubscribers();

        //foreach (var subscriber in subscribers) 
        //{
        //    subscriber.FirstName = "bind";
        //}

        membersDataGrid.ItemsSource = subscribers;
        //SubscribersUtils.FillComboBox(SubscribersUtils.filters, CBSort);
        //CBSort.SelectedIndex = 0;
    }

    private static List<GetSubscriber_GET> GetSubscribers() 
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var response =  httpClient.GetAsync("https://localhost:7110/subscriber/getAll").Result;
                response.EnsureSuccessStatusCode();

                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var subscribers = JsonSerializer.Deserialize<List<GetSubscriber_GET>>(jsonResponse);

                return subscribers;
            }
            catch (HttpRequestException ex)
            {
                // Обработка ошибок при запросе к API
                Console.WriteLine($"Ошибка при получении подписчиков: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                // Обработка ошибок при десериализации JSON-ответа
                Console.WriteLine($"Ошибка при десериализации JSON-ответа: {ex.Message}");
                throw;
            }
        }
            
    }

    private void ActiveBtn_Click(object sender, RoutedEventArgs e)
    {
    //    List<GetSubscriber_GET> membersActive = [];
    //    membersActive = membersCopy.Where(
    //        m => m.DateOfTermination > DateOnly.FromDateTime(DateTime.Now) ||
    //        m.DateOfTermination == null).ToList();
    //    membersChanged = membersActive;
    //    SubscribersUtils.UpdateList(membersDataGrid, membersActive);
    //    contentBtn = SubscribersUtils.ButtonThicknessChange(ActiveBtn, btnStack);
    //    SubscribersUtils.FillComboBox("Активные", CBSort);
    //    CBSort.SelectedIndex = 0;
    }
    private void InactiveBtn_Click(object sender, RoutedEventArgs e)
    {
    //    List<GetSubscriber_GET> membersInactive = [];
    //    membersInactive = membersCopy.Where(
    //        m => m.DateOfTermination < DateOnly.FromDateTime(DateTime.Now))
    //        .ToList();
    //    membersChanged = membersInactive;
    //    SubscribersUtils.UpdateList(membersDataGrid, membersInactive);
    //    contentBtn = SubscribersUtils.ButtonThicknessChange(InactiveBtn, btnStack);
    //    SubscribersUtils.FillComboBox("Неактивные", CBSort);
    //    CBSort.SelectedIndex = 0;
    }

    private void ServicesBtn_Click(object sender, RoutedEventArgs e)
    {
    //    if (!servicesPressed)
    //    {
    //        SubscribersUtils.FillComboBox(services, CBSort);
    //        contentBtn = SubscribersUtils.ButtonThicknessChange(ServicesBtn, btnStack);
    //        CBSort.SelectedIndex = 0;
    //        servicesPressed = true;
    //    }
    //    //CBSort.SelectionChanged += CBSort_SelectionChanged;
    }
    private void FullNameBtn_Click(object sender, RoutedEventArgs e)
    {
    //    SubscribersUtils.FillComboBox("ФИО", CBSort);
    //    contentBtn = SubscribersUtils.ButtonThicknessChange(FullNameBtn, btnStack);
    //    CBSort.SelectedIndex = 0;
    //    membersChanged = membersCopy;
    //    SubscribersUtils.UpdateList(membersDataGrid, membersChanged);
    }

    private void BillBtn_Click(object sender, RoutedEventArgs e)
    {
    //    SubscribersUtils.FillComboBox("Лицевой счет", CBSort);
    //    contentBtn = SubscribersUtils.ButtonThicknessChange(BillBtn, btnStack);
    //    CBSort.SelectedIndex = 0;
    //    membersChanged = membersCopy;
    //    SubscribersUtils.UpdateList(membersDataGrid, membersChanged);
    }

    private void ContractNumberBtn_Click(object sender, RoutedEventArgs e)
    {
    //    SubscribersUtils.FillComboBox("Номер договора", CBSort);
    //    contentBtn = SubscribersUtils.ButtonThicknessChange(ContractNumberBtn, btnStack);
    //    CBSort.SelectedIndex = 0;
    //    membersChanged = membersCopy;
    //    SubscribersUtils.UpdateList(membersDataGrid, membersChanged);
    }



    private void TxtSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
    //    List<GetSubscriber_GET> membersLocal = [];

    //    membersLocal = membersChanged.Where(sub =>
    //    sub.Name.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase) ||
    //    sub.PersonaAccount.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase) ||
    //    sub.Services.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
    //        .ToList();

    //    if (txtSearch.Text == "")
    //        membersDataGrid.ItemsSource = membersChanged;
    //    membersDataGrid.ItemsSource = membersLocal;
    }

    

    private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    //    List<GetSubscriber_GET> localMembers = [];
    //    var tb = (TextBlock)CBSort.SelectedValue;

    //    if (tb != null)
    //    {
    //        foreach (var filter in SubscribersUtils.filters)
    //        {
    //            if (tb.Text.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
    //            {
    //                switch (contentBtn)
    //                {
    //                    case "Активные":
    //                        Filter(filter, x => x.Name);
    //                        break;

    //                    case "Неактивные":
    //                        Filter(filter, x => x.Name);
    //                        break;

    //                    case "Услуги":
    //                        Filter(filter, x => x.Services);
    //                        break;

    //                    case "Лицевой счет":
    //                        Filter(filter, x => x.NumberUser);
    //                        break;

    //                    case "Номер договора":
    //                        Filter(filter, x => x.NumberContract);
    //                        break;

    //                    case "ФИО":
    //                        Filter(filter, x => x.Name);
    //                        break;

    //                }
    //            }
    //        }

    //        if (servicesPressed)
    //        {
    //            localMembers = membersCopy.Where(
    //                m => m.Services == tb.Text)
    //                .ToList();
    //            membersChanged = localMembers;
    //            SubscribersUtils.UpdateList(membersDataGrid, localMembers);
    //            servicesPressed = false;
    //        }
    //    }
    }

    void Filter(string filter, Func<GetSubscriber_GET, string> predicate)
    {
    //    List<GetSubscriber_GET> filtersMembersChanged = [];

    //    filtersMembersChanged = filter.ToLower() switch
    //    {
    //        "по возрастанию" => [.. membersChanged.OrderBy(predicate)],
    //        "по убыванию" => [.. membersChanged.OrderByDescending(predicate)],
    //        _ => new(membersChanged),
    //    };
    //    //switch (filter.ToLower())
    //    //{
    //    //    case "по возрастанию":
    //    //        membersChanged = [.. membersChanged.OrderBy(predicate)];
    //    //        break;

    //    //    case "по убыванию":
    //    //        membersChanged = [.. membersChanged.OrderByDescending(predicate)];
    //    //        break;

    //    //    default:
    //    //        membersChanged = new(membersCopy);
    //    //        break;
    //    //}
    //    SubscribersUtils.UpdateList(membersDataGrid, filtersMembersChanged);
    }

    private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
    {
    //    SubscribersUtils.ButtonThicknessChange(addButton, btnStack);
    //    membersCopy = new(members);
    //    membersChanged = new(members);
    //    SubscribersUtils.UpdateList(membersDataGrid, membersCopy);
    //    SubscribersUtils.FillComboBox(SubscribersUtils.filters, CBSort);

    }

    private async void AddButton(object sender, RoutedEventArgs e)
    {
        AddUser addUser = new AddUser();
        addUser.Show();
    }

    private  void Open_MouseDown(object sender, MouseButtonEventArgs e)
    {

        var ellipse = sender as Ellipse;
        var subscriber = ellipse.DataContext as GetSubscriber_GET;
        //get person by personId
        OpenUser openUser = new OpenUser(this, subscriber);
        openUser.Show();
        addButton.IsEnabled = false;


    }

    private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
    {
        EditUser editUser = new EditUser();
        editUser.Show();
    }

    private void DeleteMouseDown(object sender, MouseButtonEventArgs e)
    {
        string messageBox = "Вы точно хотите удалить...";
        ShowMessage(messageBox);

    }

    public static MessageBoxResult ShowMessage(string message)
    {
        var dialog = new MessageWindow();
        dialog.MessageContainer.Text = message;
        dialog.ShowDialog();
        return MessageBoxResult.None;
    }
}
