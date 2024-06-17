using System.Windows;
using System.Windows.Input;
using TNS.Front_end.CRM.MODELS;
using TNS.Front_end.Employee.MODELS;
using TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow: Window 
    {
        public MessageWindow(string message)
        {
            InitializeComponent();
            MessageContainer.Text = message;
            ShowDialog();
        }

        public MessageWindow(string message, GetSubscriber_GET entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
        }

        public MessageWindow(string message, GetAllBaseStations_GET entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
        }

        public MessageWindow(string message, GetAllCRM_GET entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
        }

        public MessageWindow(string message, GetAllEmployees_GET entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
        }

        public MessageWindow(string message, GetAllEquipments_GET entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно
    }
}
