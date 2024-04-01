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
        public Autorization()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            panelWidth = 255;
            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();
            
            members.Add(new Member { Number = "1", Character = "Д", Name = "Дроздов Алексей Петрович", NumberUser = "1230", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "000" });
            members.Add(new Member { Number = "2", Character = "К", Name = "Кулич Татьяна Юрьевна", NumberUser = "1231", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "001" });
            members.Add(new Member { Number = "3", Character = "У", Name = "Уль Дмитрий Максимович", NumberUser = "1232", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "002" });
            members.Add(new Member { Number = "4", Character = "Н", Name = "Новоселова Ирина Дмитриевна", NumberUser = "1233", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "003" });
            members.Add(new Member { Number = "5", Character = "А", Name = "Алексеев Алексей Васильевич", NumberUser = "1234", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "004" });
            members.Add(new Member { Number = "6", Character = "Р", Name = "Рогачева Евгения Валерьевна", NumberUser = "1235", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "005" });
            members.Add(new Member { Number = "7", Character = "Г", Name = "Горбачев Игорь Иванович", NumberUser = "1236", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "006" });
            members.Add(new Member { Number = "8", Character = "Ш"  , Name = "Шиканова Ирина Сергеевна", NumberUser = "1237", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "007" });
            members.Add(new Member { Number = "9", Character = "Ф", Name = "Филимонов Андрей Андреевич", NumberUser = "1238", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "008" });
            members.Add(new Member { Number = "10", Character = "З", Name = "Зверева Анастасия Андреевна", NumberUser = "1239", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "009" });
            members.Add(new Member { Number = "1", Character = "Д", Name = "Дроздов Алексей Петрович", NumberUser = "1230", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "000" });
            members.Add(new Member { Number = "2", Character = "К", Name = "Кулич Татьяна Юрьевна", NumberUser = "1231", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "001" });
            members.Add(new Member { Number = "3", Character = "У", Name = "Уль Дмитрий Максимович", NumberUser = "1232", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "002" });
            members.Add(new Member { Number = "4", Character = "Н", Name = "Новоселова Ирина Дмитриевна", NumberUser = "1233", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "003" });
            members.Add(new Member { Number = "5", Character = "А", Name = "Алексеев Алексей Васильевич", NumberUser = "1234", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "004" });
            members.Add(new Member { Number = "6", Character = "Р", Name = "Рогачева Евгения Валерьевна", NumberUser = "1235", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "005" });
            members.Add(new Member { Number = "7", Character = "Г", Name = "Горбачев Игорь Иванович", NumberUser = "1236", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "006" });
            members.Add(new Member { Number = "8", Character = "Ш", Name = "Шиканова Ирина Сергеевна", NumberUser = "1237", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "007" });
            members.Add(new Member { Number = "9", Character = "Ф", Name = "Филимонов Андрей Андреевич", NumberUser = "1238", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "008" });
            members.Add(new Member { Number = "10", Character = "З", Name = "Зверева Анастасия Андреевна", NumberUser = "1239", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "009" });
            members.Add(new Member { Number = "1", Character = "Д", Name = "Дроздов Алексей Петрович", NumberUser = "1230", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "000" });
            members.Add(new Member { Number = "2", Character = "К", Name = "Кулич Татьяна Юрьевна", NumberUser = "1231", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "001" });
            members.Add(new Member { Number = "3", Character = "У", Name = "Уль Дмитрий Максимович", NumberUser = "1232", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "002" });
            members.Add(new Member { Number = "4", Character = "Н", Name = "Новоселова Ирина Дмитриевна", NumberUser = "1233", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "003" });
            members.Add(new Member { Number = "5", Character = "А", Name = "Алексеев Алексей Васильевич", NumberUser = "1234", PersonaAccount = "459235346", Services = "Телевидение", NumberContract = "004" });
            members.Add(new Member { Number = "6", Character = "Р", Name = "Рогачева Евгения Валерьевна", NumberUser = "1235", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "005" });
            members.Add(new Member { Number = "7", Character = "Г", Name = "Горбачев Игорь Иванович", NumberUser = "1236", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "006" });
            members.Add(new Member { Number = "8", Character = "Ш", Name = "Шиканова Ирина Сергеевна", NumberUser = "1237", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "007" });
            members.Add(new Member { Number = "9", Character = "Ф", Name = "Филимонов Андрей Андреевич", NumberUser = "1238", PersonaAccount = "459235346", Services = "Интернет", NumberContract = "008" });
            members.Add(new Member { Number = "10", Character = "З", Name = "Зверева Анастасия Андреевна", NumberUser = "1239", PersonaAccount = "459235346", Services = "Мобильная связь", NumberContract = "009" });
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
        }
        private void Timer_Tick (object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 3;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 3;
                if (sidePanel.Width <= 100)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
            //if (hidden == false)
            //{
            //    sidePanel.Width += 100;
            //    if (sidePanel.Width >= panelWidth)
            //    {
            //        timer.Stop();
            //        hidden = true;
            //    }
            //}
            //else
            //{
            //    sidePanel.Width -= 3;
            //    if (sidePanel.Width <= 55)
            //    {
            //        timer.Stop();
            //        hidden = false;
            //    }
            //}
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
            ContentFrame.Navigate(typeof(Autorization));
        }

        private void ListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Start();
        }

        private void Activ(object sender, RoutedEventArgs e)
        {

        }

        private void Passiv(object sender, RoutedEventArgs e)
        {

        }
    }
}
