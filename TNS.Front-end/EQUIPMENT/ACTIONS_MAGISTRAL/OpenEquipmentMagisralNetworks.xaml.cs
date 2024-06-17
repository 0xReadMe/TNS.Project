using System.Windows;
using System.Windows.Input;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для OpenEquipmentMagisralNetworks.xaml
    /// </summary>
    public partial class OpenEquipmentMagisralNetworks : Window
    {
        public OpenEquipmentMagisralNetworks(EquipmentMagisralNetworks page, GetAllEquipments_GET _emp)
        {
            InitializeComponent();

            tbName.Text = _emp.Name;
            tbFrequency.Text = _emp.Frequency.ToString();
            tbCoefficien.Text = _emp.AttenuationCoefficient.ToString();
            tbDTT.Text = _emp.DTT;
            tbAddress.Text = _emp.Address;

        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно
    }
}
