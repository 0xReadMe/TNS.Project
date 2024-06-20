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
        GetSubscriber_GET _sub;

        public EditUser(GetSubscriber_GET sub, Subscribers mainFrame)
        {
            InitializeComponent();

            _mainFrame = mainFrame;
            _sub = sub;
            tbFullName.Text = $"{sub.FirstName} {sub.MiddleName} {sub.LastName}";
            tbPassportSeries.Text = sub.Series.ToString();
            tbPassportNumber.Text = sub.Number.ToString();
            tbPassportIssueDate.SelectedDate = sub.DateOfIssueOfPassport.ToDateTime(TimeOnly.MinValue);
            tbPassportWhoIssued.Text = sub.IssuedBy;
            tbStartDate.SelectedDate = sub.DateOfContractConclusion.ToDateTime(TimeOnly.MinValue);

            tbTypeContract.ItemsSource = ComboBoxSort.TypeContract;

            if (sub.ContractType == true) 
            {
                tbTypeContract.SelectedValue = "С пролонгацией";
            }
            else
            {
                tbTypeContract.SelectedValue = "Без пролонгации";
            }

            tbEndDate.SelectedDate = sub.DateOfTerminationOfTheContract.ToDateTime(TimeOnly.MinValue);
            
            tbReasonTermination.ItemsSource = ComboBoxSort.ReasonsForTermination;
            tbReasonTermination.SelectedValue = sub.ReasonForTerminationOfContract;

            tbPersonalAccount.Text = sub.PersonalBill.ToString();
            tbAddress.Text = sub.ResidenceAddress;

            tbServices.ItemsSource = ComboBoxSort.Services;
            tbServices.SelectedValue = sub.Services;

            tbDataEquipment.ItemsSource = ComboBoxSort.TypeEquipment;
            tbDataEquipment.SelectedValue = sub.TypeOfEquipment;
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) 
        {
            _mainFrame.addButton.IsEnabled = true;
            Close();
        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            tbFullName.Clear();
            tbPassportSeries.Clear();
            tbPassportNumber.Clear();
            tbPassportIssueDate.SelectedDate = DateTime.Now;
            tbPassportWhoIssued.Clear();
            tbStartDate.SelectedDate = _sub.DateOfContractConclusion.ToDateTime(TimeOnly.MinValue);

            tbTypeContract.ItemsSource = ComboBoxSort.TypeContract;
            if (_sub.ContractType == true)
            {
                tbTypeContract.SelectedValue = "С пролонгацией";
            }
            else
            {
                tbTypeContract.SelectedValue = "Без пролонгации";
            }

            tbEndDate.Text = _sub.DateOfTerminationOfTheContract.ToString();
            tbReasonTermination.ItemsSource = ComboBoxSort.ReasonsForTermination;
            tbReasonTermination.SelectedValue = _sub.ReasonForTerminationOfContract;
            tbPersonalAccount.Text = _sub.PersonalBill.ToString();
            tbAddress.Text = _sub.ResidenceAddress;

            tbServices.ItemsSource = ComboBoxSort.Services;
            tbServices.SelectedValue = _sub.Services;
            tbDataEquipment.ItemsSource = ComboBoxSort.TypeEquipment;
            tbDataEquipment.SelectedValue = _sub.TypeOfEquipment;

        }

        string firstName, lastName, patronymic;
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool ctype;
            if (tbTypeContract.SelectedValue == "Без пролонгации")
            {
                ctype = false;
            }
            else
            {
                ctype = true;
            }
            try
            {
                SplitFullName(tbFullName.Text, out firstName, out lastName, out patronymic);

                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/subscriber/edit/&{_sub.SubscriberId}" +
                $"&ContractType={ctype}" +
                $"&ReasonForTerminationOfContract={tbReasonTermination.SelectedValue}" +
                $"&Services={tbServices.SelectedValue}" +
                $"&DateOfContractConclusion={tbStartDate.SelectedDate.Value.Year}-{tbStartDate.SelectedDate.Value.Month}-{tbStartDate.SelectedDate.Value.Day}" +
                $"&DateOfTerminationOfTheContract={tbEndDate.SelectedDate.Value.Year}-{tbEndDate.SelectedDate.Value.Month}-{tbEndDate.SelectedDate.Value.Day}" +
                $"&TypeOfEquipment={tbDataEquipment.SelectedValue}" +
                $"&FirstName={firstName}" +
                $"&MiddleName={patronymic}" +
                $"&LastName={lastName}" +
                $"&Gender=М" +
                $"&DOB={DateTime.Now.Year - 18}-{DateTime.Now.Month}-{DateTime.Now.Day}" +
                $"&PhoneNumber=89065787986" +
                $"&Email=xxx.is.04@mail.ru" +
                $"&DivisionCode=500-046" +
                $"&IssuedBy={tbPassportWhoIssued.Text}" +
                $"&Series={Convert.ToInt32(tbPassportSeries.Text)}" +
                $"&Number={Convert.ToInt32(tbPassportNumber.Text)}" +
                $"&ResidenceAddress={tbAddress.Text}" +
                $"&ResidentialAddress={tbAddress.Text}" +
                $"&DateOfIssueOfPassport={tbPassportIssueDate.SelectedDate.Value.Year}-{tbPassportIssueDate.SelectedDate.Value.Month}-{tbPassportIssueDate.SelectedDate.Value.Day}");

                _mainFrame.addButton.IsEnabled = true;
                Close();
            }
            catch (Exception ex)
            {
                _mainFrame.addButton.IsEnabled = true;
                var dialog = new MessageWindow($"{ex}");
            }
        }

        public void SplitFullName(string fullName, out string firstName, out string lastName, out string patronymic)
        {
            string[] nameParts = fullName.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length == 3)
            {
                firstName = nameParts[1];
                lastName = nameParts[0];
                patronymic = nameParts[2];
            }
            else if (nameParts.Length == 2)
            {
                firstName = nameParts[1];
                lastName = nameParts[0];
                patronymic = "";
            }
            else
            {
                firstName = "";
                lastName = "";
                patronymic = "";
            }
        }
    }
}
