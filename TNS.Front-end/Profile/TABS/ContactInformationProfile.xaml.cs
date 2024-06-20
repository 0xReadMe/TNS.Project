using System.Windows.Controls;
using TNS.Front_end.Employee.MODELS;

namespace TNS.Front_end.Profile;

public partial class ContactInformationProfile : Page
{
    public ContactInformationProfile(GetAllEmployees_GET _emp)
    {
        InitializeComponent();

        emailTB.Text = _emp.Email;
        phoneTB.Text = _emp.Login;
        telegramTB.Text = _emp.Telegram;
    }
}
