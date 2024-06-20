using System.Windows;
using System.Windows.Input;
using TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для EditEquipmentAccessNetwork.xaml
    /// </summary>
    public partial class EditEquipmentAccessNetwork : Window
    {
        GetAllBaseStations_GET emp;
        public EditEquipmentAccessNetwork(EquipmentAccessNetwork page, GetAllBaseStations_GET _emp)
        {
            InitializeComponent();
            emp = _emp;
            List<string> validProtocols =
            [
                "TCP/IP",
                "UDP",
                "ICMP",
                "SNMP",
                "HTTP",
                "HTTPS",
                "FTP",
                "SFTP",
                "TELNET",
                "SSH",
                "SIP",
                "RTP",
                "RTSP"
            ];

            List<string> validTypes =
            [
                "Всенаправленная",
                "Направленная",
                "Параболическая",
                "Яги",
                "Патч",
                "Дипольная",
                "Бинаправленная",
                "Логопериодическая"
            ];

            tbAddress.Text = "Коломна, Депутатская ул, 208";
            tbLocation.Text = "Центральная площадь, возле церкви";
            tbName.Text = _emp.BaseStationName;
            tbS.Text = _emp.S.ToString();
            tbFrequency.Text = _emp.Frequency.ToString();

            cbTypeAntenna.ItemsSource = ComboBoxSort.Antenna;
            cbTypeAntenna.SelectedValue = _emp.TypeAntenna;

            tbHandover.Text = _emp.Handover.ToString();

            cbCommunicationProtocol.ItemsSource = ComboBoxSort.Protocols;
            cbCommunicationProtocol.SelectedValue = _emp.CommunicationProtocol;
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
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/editBaseStation/{emp.Id}/&{tbAddress.Text}&{tbLocation.Text}&{tbName.Text}&{tbS.Text}&{tbFrequency.Text}&{cbTypeAntenna.SelectedValue}&{tbHandover.Text}&{cbCommunicationProtocol.SelectedValue}&true");
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
