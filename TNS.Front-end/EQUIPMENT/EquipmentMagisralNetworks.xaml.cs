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
using TNS.Front_end.CRM;


namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для EquipmentMagisralNetworks.xaml
    /// </summary>
    public partial class EquipmentMagisralNetworks : Page
    {
        public EquipmentMagisralNetworks()
        {
            InitializeComponent();
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddEquipmentMagisralNetworks addWindow = new AddEquipmentMagisralNetworks();
            addWindow.Show();
        }

        private void testEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            TestEquipment testWindow = new TestEquipment();
            testWindow.Show();
        }

        private void Open_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenEquipmentMagisralNetworks openWindow  = new OpenEquipmentMagisralNetworks();
            openWindow.Show();
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditEquipmentMagisralNetworks editWindow = new EditEquipmentMagisralNetworks();
            editWindow.Show();
        }

        private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FrequencyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AttenuationCoefficientBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DTTBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddressBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
