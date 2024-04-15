using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace TNS.Front_end
{
    public class Member
    {
        public string Character { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string NumberUser { get; set; } = null!;
        public string PersonaAccount { get; set; } = null!;
        public string Services { get; set; } = null!;
        public string NumberContract { get; set; } = null!;
        public DateOnly? DateOfTermination { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        const double panelWidth = 255;
        bool hidden = true;
        bool pressed = false;

        DispatcherTimer timer = new()
        {
            Interval = new TimeSpan(0, 0, 0, 0, 10)
        };

        List<Member> members = 
        [
            new Member { Number = "1", Character = "Д", Name = "Дроздов Алексей Петрович", NumberUser = "1230", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "000", DateOfTermination = new DateOnly(2022, 2, 2) },
            new Member { Number = "2", Character = "К", Name = "Кулич Татьяна Юрьевна", NumberUser = "1231", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "001" },
            new Member { Number = "3", Character = "У", Name = "Уль Дмитрий Максимович", NumberUser = "1232", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "002", DateOfTermination = new DateOnly(2022, 2, 2) },
            new Member { Number = "4", Character = "Н", Name = "Новоселова Ирина Дмитриевна", NumberUser = "1233", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "003" },
            new Member { Number = "5", Character = "А", Name = "Алексеев Алексей Васильевич", NumberUser = "1234", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "004" },
            new Member { Number = "6", Character = "Р", Name = "Рогачева Евгения Валерьевна", NumberUser = "1235", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "005" },
            new Member { Number = "7", Character = "Г", Name = "Горбачев Игорь Иванович", NumberUser = "1236", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "006", DateOfTermination = new DateOnly(2022, 2, 2) },
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

        List<Member> membersCopy;


        public Autorization()
        {
            InitializeComponent();

            membersCopy = new(members);

            timer.Tick += Timer_Tick;
            
            membersDataGrid.ItemsSource = members;
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
            WindowState = WindowState.Minimized;
        }

        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ListViewItem_MouseDown_Autorization(object sender, MouseButtonEventArgs e)
        {
            ContentFrame.Navigate(typeof(Autorization));
        }


        private void Activ(object sender, RoutedEventArgs e)
        {
            if (!pressed)
            {
                List<Member> membersActive = [];
                membersActive = membersCopy.Where(
                    m => m.DateOfTermination > DateOnly.FromDateTime(DateTime.Now) ||
                    m.DateOfTermination == null).ToList();
                membersCopy = membersActive;
                UpdateList();

                ActiveBtn.BorderThickness = new Thickness(0, 0, 0, 2);
                InactiveBtn.BorderThickness = new Thickness(0);
                //InactiveBtn.Style = Resources["tabButton"] as Style;
                pressed = true;
            }
            else 
            {
                pressed = false;
                ActiveBtn.BorderThickness = new Thickness(0);
                membersCopy = new(members);
                UpdateList();
            }
        }

        private void Passiv(object sender, RoutedEventArgs e)
        {
            if (!pressed)
            {
                List<Member> membersInactive = [];
                membersInactive = members.Where(
                    m => m.DateOfTermination < DateOnly.FromDateTime(DateTime.Now))
                    .ToList();
                membersCopy = membersInactive;
                UpdateList();

                InactiveBtn.BorderThickness = new Thickness(0, 0, 0, 2);
                ActiveBtn.BorderThickness = new Thickness(0);
                //ActiveBtn.Style = (Style)Resources["tabButton"];

                pressed = true;
            }
            else 
            {
                pressed = false;
                InactiveBtn.BorderThickness = new Thickness(0);
                membersCopy = new(members);
                UpdateList();
            }
            
        }

        private void ListView_MouseEnter(object sender, MouseEventArgs e)
        {
            timer.Start();
        }

        private void TxtSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            List<Member> membersLocal = [];

            membersLocal = members.Where(sub => 
            sub.Name.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase) || 
            sub.PersonaAccount.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase) ||
            sub.Services.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            if (txtSearch.Text == "") 
                membersDataGrid.ItemsSource = members;
            membersDataGrid.ItemsSource = membersLocal;
        }

        private void InternetBtn_Click(object sender, RoutedEventArgs e)
        {
            var services = GetUniqServices();
            CBSort.Items.Clear();
            foreach (var service in services) 
            {
                TextBlock tb = new()
                {
                    Text = service
                };

                CBSort.Items.Add(tb);
            }
        }

        private void NumberSubsciberBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FullNameBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BillBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContractNumberBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        void UpdateList() => membersDataGrid.ItemsSource = membersCopy;
        List<string> GetUniqServices() 
        {
            List<string> services = [];

            foreach (var member in members) 
            {
                services.Add(member.Services);
            }
            return services.Distinct().ToList();
        }
    }
}
