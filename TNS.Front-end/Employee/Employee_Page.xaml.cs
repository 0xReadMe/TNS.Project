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
        string chooseFilter;

        public Employee_Page()
        {
            InitializeComponent();

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
                    case "Должность":
                        PositionNameBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    case "Телефон":
                        PhoneBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    case "E-mail":
                        EmailBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    case "Дата рождения":
                        DateBirthBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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

            List<GetAllEmployees_GET> findList = FindInfo.Find<GetAllEmployees_GET>(membersDataGrid, txtSearch);
            Update(findList);
        }

        private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {
            chooseFilter = "";
            _employee = ApiContext.Get<GetAllEmployees_GET>($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/employee/getAll");
            Update(_employee);
            FilterBlock.ButtonThicknessChange(addButton, btnStack);
            ComboBoxSort.FillComboBox(ComboBoxSort.Filters, CBSort);
            CBSort.SelectedIndex = 0;
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
            chooseFilter = FilterBlock.ButtonThicknessChange(PositionNameBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_employee);

        }

        private void PhoneBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(PhoneBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_employee);
        }

        private void DateBirthBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(DateBirthBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_employee);
        }

        private void EmailBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(EmailBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_employee);
        }

        private void FullNameBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(FullNameBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_employee);
        }

        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllEmployees_GET;

            string message = $"Вы точно хотите удалить сотрудника \"{subscriber.FullName}\"?";
            var dialog = new MessageWindow(message, subscriber);

            addButton.IsEnabled = false;
        }

        private void Update(List<GetAllEmployees_GET> sub) => membersDataGrid.ItemsSource = sub;
    }
}
