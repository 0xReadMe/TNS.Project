using System.Windows;
using System.Windows.Input;
using TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для OpenEquipmentAccessNetwork.xaml
    /// </summary>
    public partial class OpenEquipmentAccessNetwork : Window
    {
        public OpenEquipmentAccessNetwork(EquipmentAccessNetwork page, GetAllBaseStations_GET _emp)
        {
            InitializeComponent();

            tbAddress.Text = "улица Пушкина, дом 248";
            tbLocation.Text = "Центральная площадь";
            tbName.Text = _emp.BaseStationName;
            tbS.Text = _emp.S.ToString();
            tbFrequency.Text = _emp.Frequency.ToString();
            tbTypeAntenna.Text = _emp.TypeAntenna.ToString();
            tbHandover.Text = _emp.Handover.ToString();
            tbCommunicationProtocol.Text = _emp.CommunicationProtocol.ToString();
            tbIsWorking.Text = _emp.IsWorking ? "Работает" : "Не работает";
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно
    }
}
