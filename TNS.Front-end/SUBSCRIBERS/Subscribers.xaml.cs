using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end;

/// <summary>
/// Логика взаимодействия для MainFrame.xaml
/// </summary>
public partial class Subscribers : Page
{
    public AddUser AboutWindow;
    string chooseFilter;
    List<GetSubscriber_GET> subscribers;
    
    public Subscribers()
    {
        InitializeComponent();
        
        MouseButtonEventArgs args = new(Mouse.PrimaryDevice, 0, MouseButton.Left)
        {
            RoutedEvent = Image.MouseDownEvent
        };
        refreshBtn.RaiseEvent(args);
    }

    private void ActiveBtn_Click(object sender, RoutedEventArgs e)
    {
        List<GetSubscriber_GET> active = subscribers
            .Where(m => m.DateOfTerminationOfTheContract > DateOnly.FromDateTime(DateTime.Now) 
            || m.DateOfTerminationOfTheContract == null).ToList();

        chooseFilter = FilterBlock.ButtonThicknessChange(ActiveBtn, btnStack);
        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0;

        Update(active);
    }
    private void InactiveBtn_Click(object sender, RoutedEventArgs e)
    {
        List<GetSubscriber_GET> inactive = subscribers.Where(
            m => m.DateOfTerminationOfTheContract < DateOnly.FromDateTime(DateTime.Now)).ToList();

        chooseFilter = FilterBlock.ButtonThicknessChange(InactiveBtn, btnStack);
        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0;

        Update(inactive);
    }

    private void ServicesBtn_Click(object sender, RoutedEventArgs e)
    {
        chooseFilter = FilterBlock.ButtonThicknessChange(ServicesBtn, btnStack);
        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0;

        Update(subscribers);
    }
    private void FullNameBtn_Click(object sender, RoutedEventArgs e)
    {
        chooseFilter = FilterBlock.ButtonThicknessChange(FullNameBtn, btnStack);
        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0;

        Update(subscribers);
    }

    private void BillBtn_Click(object sender, RoutedEventArgs e)
    {
        chooseFilter = FilterBlock.ButtonThicknessChange(BillBtn, btnStack);
        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0;

        Update(subscribers);
    }

    private void ContractNumberBtn_Click(object sender, RoutedEventArgs e)
    {
        chooseFilter = FilterBlock.ButtonThicknessChange(ContractNumberBtn, btnStack);
        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0; 

        Update(subscribers);
    }

    private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (txtSearch.Text == "") 
        {
            switch (chooseFilter)
            {
                case "Активные":
                    ActiveBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case "Неактивные":
                    InactiveBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case "Услуги":
                    ServicesBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case "Лицевой счет":
                    BillBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case "Номер договора":
                    ContractNumberBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case "ФИО":
                    FullNameBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                default:
                    MouseButtonEventArgs args = new(Mouse.PrimaryDevice, 0, MouseButton.Left)
                    {
                        RoutedEvent = Image.MouseDownEvent
                    };
                    refreshBtn.RaiseEvent(args);
                    break;
            }
        }

        List<GetSubscriber_GET> findList = FindInfo.Find<GetSubscriber_GET>(membersDataGrid, txtSearch);
        Update(findList);
    }

    private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var result = ComboBoxSort.ChangeCB<GetSubscriber_GET>(CBSort, chooseFilter, membersDataGrid);
        Update(result);
    }

    private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
    {
        chooseFilter = "";
        subscribers = ApiContext.Get<GetSubscriber_GET>($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/subscriber/getAll");
        Update(subscribers);
        FilterBlock.ButtonThicknessChange(addButton, btnStack);
        ComboBoxSort.FillComboBox(ComboBoxSort.Filters, CBSort);
        CBSort.SelectedIndex = 0;
    }

    private async void AddButton(object sender, RoutedEventArgs e)
    {
        AddUser addUser = new(this);
        addUser.Show();
    }

    private  void Open_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var ellipse = sender as Ellipse;
        var subscriber = ellipse.DataContext as GetSubscriber_GET;

        OpenUser openUser = new(this, subscriber);
        openUser.Show();

        addButton.IsEnabled = false;
    }

    private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var ellipse = sender as Ellipse;
        var subscriber = ellipse.DataContext as GetSubscriber_GET;

        EditUser editUser = new(subscriber, this);
        editUser.Show();

        addButton.IsEnabled = false;
    }

    private void DeleteMouseDown(object sender, MouseButtonEventArgs e)
    {
        var ellipse = sender as Ellipse;
        var subscriber = ellipse.DataContext as GetSubscriber_GET;

        string message = $"Вы точно хотите удалить абонента \"{subscriber.FirstName} {subscriber.MiddleName} {subscriber.LastName}\"?";
        var dialog = new MessageWindow(message, subscriber);
        
        addButton.IsEnabled = false;

    }

    private void Update(List<GetSubscriber_GET> sub) => membersDataGrid.ItemsSource = sub;
}
