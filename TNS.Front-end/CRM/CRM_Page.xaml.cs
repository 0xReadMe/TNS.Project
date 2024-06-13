using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TNS.Front_end.CRM;

/// <summary>
/// Логика взаимодействия для CRM.xaml
/// </summary>
public partial class CRM_Page : Page
{
    //List<string> services = [];
    //List<CRM_request> members =
    //[
    //    new CRM_request { Id = "id" , NumberRequest = "number", AbonentNumber = "8989898989", Service = "Интернет", Status = "Открыта", TypeEquipment = "УАЗ-21" },
    //    new CRM_request { Id = "id", NumberRequest = "number", AbonentNumber = "8989898989", Service = "Телевидение", Status = "Закарыта", TypeEquipment = "УАЗ-21" },
    //    new CRM_request { Id = "id", NumberRequest = "number", AbonentNumber = "8989898989", Service = "Мобильная связь", Status = "Открыта", TypeEquipment = "УАЗ-21" },
    //    new CRM_request { Id = "id", NumberRequest = "number", AbonentNumber = "8989898989", Service = "Интернет", Status = "Закрыта", TypeEquipment = "УАЗ-21" },
       
    //];

    //List<CRM_request> membersCopy;
    //List<CRM_request> membersChanged;

    public CRM_Page()
    {
        InitializeComponent();
        //membersCopy = new(members);
        //membersDataGrid.ItemsSource = members;
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
        AddCRM addCRM = new AddCRM();
        addCRM.Show();
    }

    private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
    {
        EditCRM editCRM = new EditCRM();
        editCRM.Show();
    }

    private void Open_MouseDown(object sender, MouseButtonEventArgs e)
    {
        OpenCRM openCRM = new OpenCRM();
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
}
