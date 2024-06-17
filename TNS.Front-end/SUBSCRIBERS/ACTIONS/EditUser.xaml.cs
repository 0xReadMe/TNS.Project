using System.Net;
using System.Windows;
using System.Windows.Input;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        Subscribers _mainFrame;

        public EditUser(GetSubscriber_GET sub, Subscribers mainFrame)
        {
            InitializeComponent();

            _mainFrame = mainFrame;
            tbFullName.Text = $"{sub.FirstName} {sub.MiddleName} {sub.LastName}";
            tbPassportSeries.Text = sub.Series.ToString();
            tbPassportNumber.Text = sub.Number.ToString();
            tbPassportIssueDate.SelectedDate = sub.DateOfIssueOfPassport.ToDateTime(TimeOnly.MinValue);
            tbPassportWhoIssued.Text = sub.IssuedBy;
            tbStartDate.SelectedDate = sub.DateOfContractConclusion.ToDateTime(TimeOnly.MinValue);

            List<string> typeContract = ["С пролонгацией", "Без пролонгации"];
            tbTypeContract.ItemsSource = typeContract;
            tbTypeContract.SelectedIndex = 0;

            tbEndDate.SelectedDate = sub.DateOfTerminationOfTheContract.ToDateTime(TimeOnly.MinValue);
            tbReasonTermination.Text = sub.ReasonForTerminationOfContract;
            tbPersonalAccount.Text = sub.PersonalBill.ToString();
            tbAddress.Text = sub.ResidenceAddress;

            List<string> servicesExist = [
                "Интернет",
                "Мобильная связь",
                "Телевидение",
                "Видеонаблюдение"];
            tbServices.ItemsSource = servicesExist;
            tbServices.SelectedIndex = 0;

            tbDataEquipment.Text = sub.TypeOfEquipment;
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) 
        {
            _mainFrame.addButton.IsEnabled = true;
            Close();
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            //tbFullName.Clear();
            //tbPassportSeries.Clear();
            //tbPassportNumber.Clear();
            //tbPassportIssueDate.SelectedDate = DateTime.Now;
            //tbPassportWhoIssued.Clear();
            //tbStartDate.SelectedDate = sub.DateOfContractConclusion.ToDateTime(TimeOnly.MinValue);

            //List<string> typeContract = ["С пролонгацией", "Без пролонгации"];
            //tbTypeContract.ItemsSource = typeContract;

            //tbEndDate.Text = sub.DateOfTerminationOfTheContract.ToString();
            //tbReasonTermination.Text = sub.ReasonForTerminationOfContract;
            //tbPersonalAccount.Text = sub.PersonalBill.ToString();
            //tbAddress.Text = sub.ResidenceAddress;

            //List<string> servicesExist = ["С пролонгацией", "Без пролонгации"];
            //tbServices.ItemsSource = servicesExist;

            //tbDataEquipment.Text = sub.TypeOfEquipment;
        }
    }
}
