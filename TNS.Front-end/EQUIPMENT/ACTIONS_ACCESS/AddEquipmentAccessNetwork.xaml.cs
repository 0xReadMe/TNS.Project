using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Input;
using TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для AddEquipmentAccessNetwork.xaml
    /// </summary>
    public partial class AddEquipmentAccessNetwork : Window
    {
        EquipmentAccessNetwork _main;
        public AddEquipmentAccessNetwork(EquipmentAccessNetwork main)
        {
            InitializeComponent();
            _main = main;

            cbTypeAntenna.ItemsSource = ComboBoxSort.Antenna;
            cbCommunicationProtocol.ItemsSource = ComboBoxSort.Protocols;
            cbTypeAntenna.SelectedIndex = 0;
            cbCommunicationProtocol.SelectedIndex = 0;

        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
                tbAddress.Clear();
                tbLocation.Clear();
                tbName.Clear();
                tbS.Clear();
                tbFrequency.Clear();
                cbTypeAntenna.ItemsSource = ComboBoxSort.Antenna;
                tbHandover.Clear();
                cbCommunicationProtocol.ItemsSource = ComboBoxSort.Protocols;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/addBaseStation/&{tbAddress.Text}&{tbLocation.Text}&{tbName.Text}&{tbS.Text}&{tbFrequency.Text}&{cbTypeAntenna.SelectedValue}&{tbHandover.Text}&{cbCommunicationProtocol.SelectedValue}&true");
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
