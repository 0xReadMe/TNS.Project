using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using static TNS.Front_end.Autorization;

namespace TNS.Front_end
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        DispatcherTimer timer;
        double panelWidth;
        bool hidden = true;
        ObservableCollection<Member> members = [];

        public Autorization()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            panelWidth = 255;
            var converter = new BrushConverter();
            members =
            [
                new Member { Number = "1", Character = "Д", Name = "Дроздов Алексей Петрович", NumberUser = "1230", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "000", DateOfTermination = new DateOnly(2022, 2, 2)},
                new Member { Number = "2", Character = "К", Name = "Кулич Татьяна Юрьевна", NumberUser = "1231", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "001" },
                new Member { Number = "3", Character = "У", Name = "Уль Дмитрий Максимович", NumberUser = "1232", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "002", DateOfTermination = new DateOnly(2022, 2, 2) },
                new Member { Number = "4", Character = "Н", Name = "Новоселова Ирина Дмитриевна", NumberUser = "1233", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "003" },
                new Member { Number = "5", Character = "А", Name = "Алексеев Алексей Васильевич", NumberUser = "1234", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "004" },
                new Member { Number = "6", Character = "Р", Name = "Рогачева Евгения Валерьевна", NumberUser = "1235", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "005" },
                new Member { Number = "7", Character = "Г", Name = "Горбачев Игорь Иванович", NumberUser = "1236", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "006", DateOfTermination = new DateOnly(2022, 2, 2) },
                new Member { Number = "8", Character = "Ш"  , Name = "Шиканова Ирина Сергеевна", NumberUser = "1237", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "007" },
                new Member { Number = "9", Character = "Ф", Name = "Филимонов Андрей Андреевич", NumberUser = "1238", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "008" },
                new Member { Number = "10", Character = "З", Name = "Зверева Анастасия Андреевна", NumberUser = "1239", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "009" },
                new Member { Number = "1", Character = "Д", Name = "Дроздов Алексей Петрович", NumberUser = "1230", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "000" },
                new Member { Number = "2", Character = "К", Name = "Кулич Татьяна Юрьевна", NumberUser = "1231", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "001" },
                new Member { Number = "3", Character = "У", Name = "Уль Дмитрий Максимович", NumberUser = "1232", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "002" },
                new Member { Number = "4", Character = "Н", Name = "Новоселова Ирина Дмитриевна", NumberUser = "1233", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "003" },
                new Member { Number = "5", Character = "А", Name = "Алексеев Алексей Васильевич", NumberUser = "1234", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "004" },
                new Member { Number = "6", Character = "Р", Name = "Рогачева Евгения Валерьевна", NumberUser = "1235", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "005" },
                new Member { Number = "7", Character = "Г", Name = "Горбачев Игорь Иванович", NumberUser = "1236", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "006" },
                new Member { Number = "8", Character = "Ш", Name = "Шиканова Ирина Сергеевна", NumberUser = "1237", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "007" },
                new Member { Number = "9", Character = "Ф", Name = "Филимонов Андрей Андреевич", NumberUser = "1238", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "008" },
                new Member { Number = "10", Character = "З", Name = "Зверева Анастасия Андреевна", NumberUser = "1239", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "009" },
                new Member { Number = "1", Character = "Д", Name = "Дроздов Алексей Петрович", NumberUser = "1230", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "000" },
                new Member { Number = "2", Character = "К", Name = "Кулич Татьяна Юрьевна", NumberUser = "1231", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "001" },
                new Member { Number = "3", Character = "У", Name = "Уль Дмитрий Максимович", NumberUser = "1232", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "002" },
                new Member { Number = "4", Character = "Н", Name = "Новоселова Ирина Дмитриевна", NumberUser = "1233", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "003" },
                new Member { Number = "5", Character = "А", Name = "Алексеев Алексей Васильевич", NumberUser = "1234", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "004" },
                new Member { Number = "6", Character = "Р", Name = "Рогачева Евгения Валерьевна", NumberUser = "1235", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "005" },
                new Member { Number = "7", Character = "Г", Name = "Горбачев Игорь Иванович", NumberUser = "1236", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "006" },
                new Member { Number = "8", Character = "Ш", Name = "Шиканова Ирина Сергеевна", NumberUser = "1237", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "007" },
                new Member { Number = "9", Character = "Ф", Name = "Филимонов Андрей Андреевич", NumberUser = "1238", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "008" },
                new Member { Number = "10", Character = "З", Name = "Зверева Анастасия Андреевна", NumberUser = "1239", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "009" },
            ];
            membersDataGrid.ItemsSource = members;
        }

        public class Member
        {
            public string Character { get; set; }
            public string Number { get; set; }
            public string Name { get; set; }
            public string NumberUser { get; set; }
            public string PersonaAccount { get; set; }
            public string Services { get; set; }
            public string NumberContract { get; set; }
            public DateOnly? DateOfTermination { get; set; }
        }
        private void Timer_Tick (object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 15;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 15;
                if (sidePanel.Width <= 100)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
            
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ListViewItem_MouseDown_Autorization(object sender, MouseButtonEventArgs e)
        {
            membersDataGrid.ItemsSource = members;
            ActiveBtn.BorderThickness = new Thickness(0);
            InactiveBtn.BorderThickness = new Thickness(0);
            ContentFrame.Navigate(typeof(Autorization));
            
        }


        private void Activ(object sender, RoutedEventArgs e)
        {
            List<Member> membersActive = [];
            membersActive = members.Where(m => m.DateOfTermination > DateOnly.FromDateTime(DateTime.Now) || m.DateOfTermination == null).ToList();


            membersDataGrid.ItemsSource = membersActive;

            ActiveBtn.BorderThickness = new Thickness(0, 0, 0, 2);

            InactiveBtn.BorderThickness = new Thickness(0);
            //InactiveBtn.Style = Resources["tabButton"] as Style;
            
        }

        private void Passiv(object sender, RoutedEventArgs e)
        {
            List<Member> membersInactive = [];
            membersInactive = members.Where(m => m.DateOfTermination < DateOnly.FromDateTime(DateTime.Now)).ToList();

            membersDataGrid.ItemsSource = membersInactive;

            InactiveBtn.BorderThickness = new Thickness(0, 0, 0, 2);

            ActiveBtn.BorderThickness = new Thickness(0);
            //ActiveBtn.Style = (Style)Resources["tabButton"];
        }

        private void ListView_MouseEnter(object sender, MouseEventArgs e)
        {
            timer.Start();
        }

    }
}
