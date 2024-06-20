using System.Windows;
using System.Windows.Input;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для AddEquipmentMagisralNetworks.xaml
    /// </summary>
    public partial class AddEquipmentMagisralNetworks : Window
    {
        

        public AddEquipmentMagisralNetworks()
        {
            InitializeComponent();
            
            cbDTT.ItemsSource = ComboBoxSort.DTT;
            cbDTT.SelectedIndex = 0;
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
            tbFrequency.Clear();
            tbCoefficien.Clear();
            cbDTT.ItemsSource = ComboBoxSort.DTT;
            cbDTT.SelectedIndex = 0;
            tbAddress.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/addEquipment/&АО999-ТНС-24&{tbName.Text}&{tbFrequency.Text}&{tbCoefficien.Text}&{cbDTT.SelectedValue}&{tbAddress.Text}&true");
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
