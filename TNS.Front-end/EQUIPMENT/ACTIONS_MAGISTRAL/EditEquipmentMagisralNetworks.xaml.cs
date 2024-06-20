using System.Windows;
using System.Windows.Input;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для EditEquipmentMagisralNetworks.xaml
    /// </summary>
    public partial class EditEquipmentMagisralNetworks : Window
    {
        GetAllEquipments_GET emp;
        public EditEquipmentMagisralNetworks(EquipmentMagisralNetworks page, GetAllEquipments_GET _emp)
        {
            InitializeComponent();
            emp = _emp;
            tbName.Text = _emp.Name;
            tbFrequency.Text = _emp.Frequency.ToString();
            tbCoefficien.Text = _emp.AttenuationCoefficient.ToString();

            cbDTT.ItemsSource = ComboBoxSort.DTT;
            cbDTT.SelectedValue = _emp.DTT;

            tbAddress.Text = _emp.Address;
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
            tbFrequency.Clear();
            tbCoefficien.Clear();
            cbDTT.ItemsSource = ComboBoxSort.DTT;
            tbAddress.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/editEquipment/{emp.Id}/&АО999-ТНС-24&{tbName.Text}&{tbFrequency.Text}&{tbCoefficien.Text}&{cbDTT.SelectedValue}&{tbAddress.Text}&true");
            }
            catch (Exception ex)
            {
                //_mainFrame.addButton.IsEnabled = true;
                var dialog = new MessageWindow($"{ex}");
            }
            //_mainFrame.addButton.IsEnabled = true;
            Close();
        }
    }
}
