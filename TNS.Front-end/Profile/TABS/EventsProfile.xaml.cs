using System.Windows.Controls;
using TNS.Front_end.Employee.MODELS;

namespace TNS.Front_end.Profile
{
    /// <summary>
    /// Логика взаимодействия для EventsProfile.xaml
    /// </summary>
    public partial class EventsProfile : Page
    {
        public EventsProfile(GetAllEmployees_GET _emp)
        {
            InitializeComponent();
        }
    }
}
