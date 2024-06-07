using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TNS.Front_end.CRM;

namespace TNS.Front_end.Profile
{
    /// <summary>
    /// Логика взаимодействия для ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Window
    {
        List<Page> pages = [new PersonalDataProfile(), new EventsProfile(), new ContactInformationProfile()];   // список страниц фрейма

        public ProfileUser()
        {
            InitializeComponent();
            ContentFrameProfile.Content = pages[0];
        }
        private void PersonalDataMouseDown(object sender, MouseButtonEventArgs e) => ContentFrameProfile.Content = pages[0];                            //  переход на страницу личных данных
        private void EventsProfile_MouseDown(object sender, MouseButtonEventArgs e) => ContentFrameProfile.Content = pages[1];                             //  переход на страницу событий
        private void ContactInformationProfile_MouseDown(object sender, MouseButtonEventArgs e) => ContentFrameProfile.Content = pages[2];                                   //  переход на страницу контактных данных
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)
                 => WindowState = WindowState.Minimized;
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
            => Close();

    }
}
