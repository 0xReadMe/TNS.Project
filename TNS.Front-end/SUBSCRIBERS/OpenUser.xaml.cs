using System.Windows;
using System.Windows.Input;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end
{
    /// <summary>
    /// Логика взаимодействия для OpenUser.xaml
    /// </summary>
    public partial class OpenUser : Window
    {
        Subscribers         _mainFrame;

        public OpenUser(Subscribers mainFrame, GetSubscriber_GET sub)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            tbNumberUser.Text = sub.SubscriberNumber;
            tbFullName.Text = $"{sub.FirstName} {sub.MiddleName} {sub.LastName}";
            tbPassportSeries.Text = sub.Series.ToString();
            tbPassportNumber.Text = sub.Number.ToString();
            tbPassportIssueDate.Text = sub.DateOfIssueOfPassport.ToString();
            tbPassportWhoIssued.Text = sub.IssuedBy;
            tbNumberContract.Text = sub.ContractNumber;
            tbStartDate.Text = sub.DateOfContractConclusion.ToString();
            if (sub.ContractType == false)
            {
                tbTypeContract.Text = "Без пролонгации";
            }
            else 
            {
                tbTypeContract.Text = "С пролонгацией";
            }
            tbEndDate.Text = sub.DateOfTerminationOfTheContract.ToString();
            tbReasonTermination.Text = sub.ReasonForTerminationOfContract;
            tbPersonalAccount.Text = sub.PersonalBill.ToString();
            tbAddress.Text = sub.ResidenceAddress;
            tbServices.Text = sub.Services;
            tbDataEquipment.Text = sub.TypeOfEquipment;
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)
            => WindowState = WindowState.Minimized;
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            _mainFrame.addButton.IsEnabled = true;
            Close();
        }
    }
}
