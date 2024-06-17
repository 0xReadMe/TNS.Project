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
using System.Xml.Linq;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для EditEquipmentMagisralNetworks.xaml
    /// </summary>
    public partial class EditEquipmentMagisralNetworks : Window
    {
        public EditEquipmentMagisralNetworks(EquipmentMagisralNetworks page, GetAllEquipments_GET _emp)
        {
            InitializeComponent();

            List<string> validDTTs =
            [
                "Ethernet",
                "Wi-Fi",
                "Bluetooth",
                "USB",
                "Optical Fiber",
                "SHDSL",
                "ADSL",
                "VDSL",
                "G.Fast",
                "LTE",
                "5G"
            ];

            tbName.Text = _emp.Name;
            tbFrequency.Text = _emp.Frequency.ToString();
            tbCoefficien.Text = _emp.AttenuationCoefficient.ToString();

            cbDTT.ItemsSource = validDTTs;
            cbDTT.SelectedIndex = 0;

            tbAddress.Text = _emp.Address;
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно
    }
}
