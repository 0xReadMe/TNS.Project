using System.Windows;
using System.Windows.Input;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        string firstName, lastName, patronymic;
        Subscribers _mainFrame;

        public AddUser(Subscribers mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            
            typeContractCB.ItemsSource = ComboBoxSort.TypeContract;
            serviceCB.ItemsSource = ComboBoxSort.Services;
            reasonTerminationContractTB.ItemsSource = ComboBoxSort.ReasonsForTermination;
            equipmentCB.ItemsSource = ComboBoxSort.TypeEquipment;
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)
            => WindowState = WindowState.Minimized;
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            _mainFrame.addButton.IsEnabled = true;
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool ctype;
            if (typeContractCB.SelectedValue == "Без пролонгации")
            {
                ctype = false;
            }
            else 
            {
                ctype = true; 
            }
            try
            {
                SplitFullName(fullNameTB.Text, out firstName, out lastName, out patronymic);
                
                ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/subscriber/add/" +
                $"&ContractType={ctype}" +
                $"&ReasonForTerminationOfContract={reasonTerminationContractTB.SelectedValue}" +
                $"&PersonalBill={Convert.ToUInt32(billTB.Text)}" +
                $"&Services={serviceCB.SelectedValue}" +
                $"&DateOfContractConclusion={dateConclusionDP.SelectedDate.Value.Year}-{dateConclusionDP.SelectedDate.Value.Month}-{dateConclusionDP.SelectedDate.Value.Day}" +
                $"&DateOfTerminationOfTheContract={dateOfTheTerminationDP.SelectedDate.Value.Year}-{dateOfTheTerminationDP.SelectedDate.Value.Month}-{dateOfTheTerminationDP.SelectedDate.Value.Day}" +
                $"&TypeOfEquipment={equipmentCB.SelectedValue}" +
                $"&FirstName={firstName}" +
                $"&MiddleName={patronymic}" +
                $"&LastName={lastName}" +
                $"&Gender=М" +
                $"&DOB={DateTime.Now.Year-18}-{DateTime.Now.Month}-{DateTime.Now.Day}" +
                $"&PhoneNumber=89065787986" +
                $"&Email=xxx.is.04@mail.ru" +
                $"&DivisionCode=500-046" +
                $"&IssuedBy={issuedTB.Text}" +
                $"&Series={Convert.ToInt32(seriesPassportTB.Text)}" +
                $"&Number={Convert.ToInt32(numberPassportTB.Text)}" +
                $"&ResidenceAddress={addressTB.Text}" +
                $"&ResidentialAddress={addressTB.Text}" +
                $"&DateOfIssueOfPassport={dateIssueDP.SelectedDate.Value.Year}-{dateIssueDP.SelectedDate.Value.Month}-{dateIssueDP.SelectedDate.Value.Day}");

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
