using System.Windows;
using System.Windows.Input;
using TNS.Front_end.CRM.MODELS;

namespace TNS.Front_end.CRM
{
    /// <summary>
    /// Логика взаимодействия для OpenCRM.xaml
    /// </summary>
    public partial class OpenCRM : Window
    {
        public OpenCRM(CRM_Page _mainFrame, CRM_viewmodel model)
        {
            InitializeComponent();

            tbId.Text = model.Id.ToString();
            tbSubscriberNumber.Text = model.SubscriberNumber.ToString();
            tbBilling.Text = model.PersonalBill.ToString();
            tbCreationDate.Text = model.CreationDate.ToString();
            tbService.Text = model.Service;
            tbServiceProvided.Text = model.ServiceProvided;
            tbServiceType.Text = model.ServiceType;
            tbStatus.Text = model.Status.ToString();
            tbTypeOfEquipment.Text = model.TypeOfEquipment.ToString();
            tbTypeOfProblem.Text = model.TypeOfProblem.ToString();
            tbProblemDescription.Text = model.ProblemDescription.ToString();
            tbEndDate.Text = model.ClosingDate.ToString();
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно
    }
}
