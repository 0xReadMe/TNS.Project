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
    /// Логика взаимодействия для OpenEmployee.xaml
    /// </summary>
    public partial class OpenEmployee : Window
    {
        public OpenEmployee(Employee_Page page, GetAllEmployees_GET _emp)
        {
            InitializeComponent();

            tbFullName.Text = _emp.FullName;
            tbPosition.Text = "Сотрудник";
            tbPhone.Text = _emp.Login;
            tbEmail.Text = _emp.Email;
            tbDOB.Text = _emp.DateOfBirth.ToString();
            tbTelegramm.Text = _emp.Telegram;
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно
    }
}
