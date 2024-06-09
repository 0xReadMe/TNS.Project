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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TNS.Front_end.Employee
{
    /// <summary>
    /// Логика взаимодействия для Employee_Page.xaml
    /// </summary>
    public partial class Employee_Page : Page
    {
        public Employee_Page()
        {
            InitializeComponent();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Open_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenEmployee openEmployee = new OpenEmployee();
            openEmployee.Show();
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditEmployee editEmployee = new EditEmployee();
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

        }

        private void PhoneBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DateBirthBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmailBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FullNameBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
