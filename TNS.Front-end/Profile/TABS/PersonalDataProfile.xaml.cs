using System.Windows.Controls;
using TNS.Front_end.Employee.MODELS;

namespace TNS.Front_end.Profile
{
    /// <summary>
    /// Логика взаимодействия для PersonalDataProfile.xaml
    /// </summary>
    public partial class PersonalDataProfile : Page
    {
        public PersonalDataProfile(GetAllEmployees_GET _emp)
        {
            InitializeComponent();
            string firstName, lastName, patronymic;

            SplitFullName(_emp.FullName, out firstName, out lastName, out patronymic);
            
            firstNameTb.Text = firstName;
            lastNameTB.Text = lastName;
            middleNameTB.Text = patronymic;

            dobTB.Text = _emp.DateOfBirth.ToString();
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
