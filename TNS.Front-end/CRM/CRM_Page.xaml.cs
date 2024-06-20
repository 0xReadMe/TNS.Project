using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TNS.Front_end.CRM.MODELS;
namespace TNS.Front_end.CRM;

/// <summary>
/// Логика взаимодействия для CRM.xaml
/// </summary>
public partial class CRM_Page : Page
{
    List<CRM_viewmodel> CRM;
    string chooseFilter;


    public CRM_Page()
    {
        InitializeComponent();

        membersDataGrid.ItemsSource = CRM;

        MouseButtonEventArgs args = new(Mouse.PrimaryDevice, 0, MouseButton.Left)
        {
            RoutedEvent = Image.MouseDownEvent
        };
        refreshBtn.RaiseEvent(args);
    }

    private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (txtSearch.Text == "")
        {
            switch (chooseFilter)
            {
                case "Статус":
                    StatusBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case "Тип оборудования":
                    TypeEquipmentBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                case "Тип проблемы":
                    ServicesBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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
        List<CRM_viewmodel> findList = FindInfo.Find<CRM_viewmodel>(membersDataGrid, txtSearch);
        Update(findList);
    }

    private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var result = ComboBoxSort.ChangeCB<CRM_viewmodel>(CBSort, chooseFilter, membersDataGrid);
        Update(result);
    }

    private void StatusBtn_Click(object sender, RoutedEventArgs e)
    {
        chooseFilter = FilterBlock.ButtonThicknessChange(StatusBtn, btnStack);
        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0;

        Update(CRM);
    }

    private void TypeEquipmentBtn_Click(object sender, RoutedEventArgs e)
    {
        chooseFilter = FilterBlock.ButtonThicknessChange(TypeEquipmentBtn, btnStack);
        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0;

        Update(CRM);
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
        chooseFilter = "";
        CRM = ApiContext.Get<CRM_viewmodel>($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/CRM/getAll");
        Update(CRM);
        ComboBoxSort.FillComboBox(ComboBoxSort.Filters, CBSort);
        CBSort.SelectedIndex = 0;
    }

    private void ServicesBtn_Click(object sender, RoutedEventArgs e)
    {
        chooseFilter = FilterBlock.ButtonThicknessChange(ServicesBtn, btnStack);

        ComboBoxSort.FillComboBox(chooseFilter, CBSort);
        CBSort.SelectedIndex = 0;

        Update(CRM);
    }
        
    private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var ellipse = sender as Ellipse;
        var subscriber = ellipse.DataContext as CRM_viewmodel;

        string message = $"Вы точно хотите удалить CRM \"{subscriber.Id}\"?";
        var dialog = new MessageWindow(message, subscriber);
    }
    private void Update(List<CRM_viewmodel> sub) => membersDataGrid.ItemsSource = sub;
}
