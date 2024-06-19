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
        GetSubscriber_GET _sub;
        GetAllBaseStations_GET _baseStation;
        CRM_viewmodel _crm;
        GetAllEmployees_GET _emp;
        GetAllEquipments_GET _equip;

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
            _sub = entity;
            ShowDialog();
        }

        public MessageWindow(string message, GetAllBaseStations_GET entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
            _baseStation = entity;
            ShowDialog();
        }

        public MessageWindow(string message, CRM_viewmodel entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
            _crm = entity;
            ShowDialog();
        }

        public MessageWindow(string message, GetAllEmployees_GET entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
            _emp = entity;
            ShowDialog();
        }

        public MessageWindow(string message, GetAllEquipments_GET entity)
        {
            InitializeComponent();
            MessageContainer.Text = message;
            _equip = entity;
            ShowDialog();
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (_sub != null) 
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/subscriber/delete/{_sub.SubscriberId}");
            }
            if (_baseStation != null) 
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/deleteBaseStation/{_baseStation.Id}");
            }
            if (_crm != null) 
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/CRM/delete/{_crm.Id}");
            }
            if (_emp != null) 
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/employee/delete/{_emp.Id}");
            }
            if (_equip != null) 
            {
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/deleteEquipment/{_equip.Id}");
            }
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
