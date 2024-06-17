using System.Windows;
using System.Windows.Input;
using TNS.Front_end.CRM.MODELS;

namespace TNS.Front_end.CRM
{
    /// <summary>
    /// Логика взаимодействия для EditCRM.xaml
    /// </summary>
    public partial class EditCRM : Window
    {
        public EditCRM(CRM_Page _mainFrame, CRM_viewmodel model)
        {
            InitializeComponent();

            List<string> existStatus = [
            "Новая",
            "В работе",
            "Закрыта"
            ];

            List<string> existTypeOfProblem = [
            "Консультация",
            "Техническое обслуживание"
            ];

            List<string> existServiceName = [
            "Интернет",
            "Мобильная связь",
            "Телевидение",
            "Видеонаблюдение"
        ];

            List<string> existServiceProvidedName = [
            "Подключение",
            "Управление договором/контактными данными",
            "Управление тарифом/услугой",
            "Диагностика и настройка оборудования/подключения",
            "Оплата услуг"
        ];

            List<string> existServiceTypeNames = [
            "Подключение услуг с новой инфраструктурой",
            "Подключение услуг на существующей инфраструктуре",
            "Изменение условий договора",
            "Включение в договор дополнительной услуги",
            "Изменение контактных данных",
            "Изменение тарифа",
            "Изменение адреса предоставления услуг",
            "Отключение услуги",
            "Приостановка предоставления услуги",
            "Нет доступа к услуге",
            "Разрыв соединения",
            "Низкая скорость соединения",
            "Выписка по платежам",
            "Информация о платежах",
            "Получение квитанции на оплату услуги"
        ];

            tbService.ItemsSource = existServiceName;
            tbService.SelectedIndex = 0;

            tbServiceProvided.ItemsSource = existServiceProvidedName;
            tbServiceProvided.SelectedIndex = 0;

            tbServiceType.ItemsSource = existServiceTypeNames;
            tbServiceType.SelectedIndex = 0;

            tbStatus.ItemsSource = existStatus;
            tbStatus.SelectedIndex = 0;

            tbTypeOfEquipment.Text = model.TypeOfEquipment.ToString();

            tbTypeOfProblem.ItemsSource = existTypeOfProblem;
            tbTypeOfProblem.SelectedIndex = 0;

            tbProblemDescription.Text = model.ProblemDescription.ToString();
            tbEndDate.SelectedDate = model.ClosingDate;
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно
    }
}
