using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TNS.Front_end.Employee.MODELS;

namespace TNS.Front_end.Employee
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        GetAllEmployees_GET emp;
        public EditEmployee(Employee_Page page, GetAllEmployees_GET _emp)
        {
            InitializeComponent();
            emp = _emp;
            tbFullName.Text = _emp.FullName;
            cbPosition.ItemsSource = ComboBoxSort.Roles;
            cbPosition.SelectedIndex = 3;
            tbPhone.Text = _emp.Login;
            tbEmail.Text = _emp.Email;
            tbDOB.SelectedDate = _emp.DateOfBirth.ToDateTime(new TimeOnly(12, 0, 0));
            tbTelegramm.Text = _emp.Telegram;
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/employee/edit/{emp.Id}/" +
                    $"&{tbPhone.Text}" +
                    $"&{cbPosition.SelectedIndex + 1}" +
                    $"&{tbEmail.Text}" +
                    $"&{tbFullName.Text}" +
                    $"&{tbTelegramm.Text}" +
                    $"&DateOfIssueOfPassport={tbDOB.SelectedDate.Value.Year}-{tbDOB.SelectedDate.Value.Month}-{tbDOB.SelectedDate.Value.Day}" +
                    $"&{tbPassword.Text}");

            }
            catch (Exception ex)
            {
                //_mainFrame.addButton.IsEnabled = true;
                var dialog = new MessageWindow($"{ex}");
            }
            //_mainFrame.addButton.IsEnabled = true;
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tbFullName.Clear();
            cbPosition.ItemsSource = ComboBoxSort.Roles;
            cbPosition.SelectedIndex = 0;
            tbPhone.Clear();
            tbEmail.Clear();
            tbDOB.SelectedDate = DateTime.Now;
            tbTelegramm.Clear();
        }
    }
}
