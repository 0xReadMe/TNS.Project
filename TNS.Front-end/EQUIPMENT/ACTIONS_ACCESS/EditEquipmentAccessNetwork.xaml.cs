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
        public EditEquipmentAccessNetwork(EquipmentAccessNetwork page, GetAllBaseStations_GET _emp)
        {
            InitializeComponent();

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

            tbAddress.Text = "улица Пушкина, дом 248";
            tbLocation.Text = "Центральная площадь";
            tbName.Text = _emp.BaseStationName;
            tbS.Text = _emp.S.ToString();
            tbFrequency.Text = _emp.Frequency.ToString();

            cbTypeAntenna.ItemsSource = validTypes;
            cbTypeAntenna.SelectedIndex = 7;

            tbHandover.Text = _emp.Handover.ToString();

            cbCommunicationProtocol.ItemsSource = validProtocols;
            cbCommunicationProtocol.SelectedIndex = 8;
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно
    }
}
