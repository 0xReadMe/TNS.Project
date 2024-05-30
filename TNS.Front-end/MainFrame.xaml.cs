using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Shapes;
using TNS.Front_end.Utils;

namespace TNS.Front_end
{
    /// <summary>
    /// Логика взаимодействия для MainFrame.xaml
    /// </summary>
    public partial class MainFrame : Page
    {
        public AddUser AboutWindow;
        bool servicesPressed = false;
        string contentBtn;

        List<string> services = [];
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
        List<Member> membersChanged;

        public MainFrame()
        {
            InitializeComponent();
            membersCopy = new(members);
            services = MainFrameUtils.GetUniqServices(membersCopy);

            membersDataGrid.ItemsSource = members;
            MainFrameUtils.FillComboBox(MainFrameUtils.filters, CBSort);
            CBSort.SelectedIndex = 0;
        }

        

        private void ActiveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Member> membersActive = [];
            membersActive = membersCopy.Where(
                m => m.DateOfTermination > DateOnly.FromDateTime(DateTime.Now) ||
                m.DateOfTermination == null).ToList();
            membersChanged = membersActive;
            MainFrameUtils.UpdateList(membersDataGrid, membersActive);
            contentBtn = MainFrameUtils.ButtonThicknessChange(ActiveBtn, btnStack);
            MainFrameUtils.FillComboBox("Активные", CBSort);
            CBSort.SelectedIndex = 0;
        }
        private void InactiveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Member> membersInactive = [];
            membersInactive = membersCopy.Where(
                m => m.DateOfTermination < DateOnly.FromDateTime(DateTime.Now))
                .ToList();
            membersChanged = membersInactive;
            MainFrameUtils.UpdateList(membersDataGrid, membersInactive);
            contentBtn = MainFrameUtils.ButtonThicknessChange(InactiveBtn, btnStack);
            MainFrameUtils.FillComboBox("Неактивные", CBSort);
            CBSort.SelectedIndex = 0;
        }

        private void ServicesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!servicesPressed)
            {
                MainFrameUtils.FillComboBox(services, CBSort);
                contentBtn = MainFrameUtils.ButtonThicknessChange(ServicesBtn, btnStack);
                CBSort.SelectedIndex = 0;
                servicesPressed = true;
            }
            //CBSort.SelectionChanged += CBSort_SelectionChanged;
        }
        private void FullNameBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameUtils.FillComboBox("ФИО", CBSort);
            contentBtn = MainFrameUtils.ButtonThicknessChange(FullNameBtn, btnStack);
            CBSort.SelectedIndex = 0;
            membersChanged = membersCopy;
            MainFrameUtils.UpdateList(membersDataGrid, membersChanged);
        }

        private void BillBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameUtils.FillComboBox("Лицевой счет", CBSort);
            contentBtn = MainFrameUtils.ButtonThicknessChange(BillBtn, btnStack);
            CBSort.SelectedIndex = 0;
            membersChanged = membersCopy;
            MainFrameUtils.UpdateList(membersDataGrid, membersChanged);
        }

        private void ContractNumberBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrameUtils.FillComboBox("Номер договора", CBSort);
            contentBtn = MainFrameUtils.ButtonThicknessChange(ContractNumberBtn, btnStack);
            CBSort.SelectedIndex = 0;
            membersChanged = membersCopy;
            MainFrameUtils.UpdateList(membersDataGrid, membersChanged);
        }



        private void TxtSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            List<Member> membersLocal = [];

            membersLocal = membersChanged.Where(sub =>
            sub.Name.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase) ||
            sub.PersonaAccount.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase) ||
            sub.Services.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            if (txtSearch.Text == "")
                membersDataGrid.ItemsSource = membersChanged;
            membersDataGrid.ItemsSource = membersLocal;
        }

        

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Member> localMembers = [];
            var tb = (TextBlock)CBSort.SelectedValue;

            if (tb != null)
            {
                foreach (var filter in MainFrameUtils.filters)
                {
                    if (tb.Text.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                    {
                        switch (contentBtn)
                        {
                            case "Активные":
                                Filter(filter, x => x.Name);
                                break;

                            case "Неактивные":
                                Filter(filter, x => x.Name);
                                break;

                            case "Услуги":
                                Filter(filter, x => x.Services);
                                break;

                            case "Лицевой счет":
                                Filter(filter, x => x.NumberUser);
                                break;

                            case "Номер договора":
                                Filter(filter, x => x.NumberContract);
                                break;

                            case "ФИО":
                                Filter(filter, x => x.Name);
                                break;

                        }
                    }
                }

                if (servicesPressed)
                {
                    localMembers = membersCopy.Where(
                        m => m.Services == tb.Text)
                        .ToList();
                    membersChanged = localMembers;
                    MainFrameUtils.UpdateList(membersDataGrid, localMembers);
                    servicesPressed = false;
                }
            }
        }

        void Filter(string filter, Func<Member, string> predicate)
        {
            List<Member> filtersMembersChanged = [];

            filtersMembersChanged = filter.ToLower() switch
            {
                "по возрастанию" => [.. membersChanged.OrderBy(predicate)],
                "по убыванию" => [.. membersChanged.OrderByDescending(predicate)],
                _ => new(membersChanged),
            };
            //switch (filter.ToLower())
            //{
            //    case "по возрастанию":
            //        membersChanged = [.. membersChanged.OrderBy(predicate)];
            //        break;

            //    case "по убыванию":
            //        membersChanged = [.. membersChanged.OrderByDescending(predicate)];
            //        break;

            //    default:
            //        membersChanged = new(membersCopy);
            //        break;
            //}
            MainFrameUtils.UpdateList(membersDataGrid, filtersMembersChanged);
        }

        private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrameUtils.ButtonThicknessChange(addButton, btnStack);
            membersCopy = new(members);
            membersChanged = new(members);
            MainFrameUtils.UpdateList(membersDataGrid, membersCopy);
            MainFrameUtils.FillComboBox(MainFrameUtils.filters, CBSort);

        }

        private async void AddButton(object sender, RoutedEventArgs e)
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    var responce = await client.GetAsync("https://localhost:7110");
            //    responce.EnsureSuccessStatusCode();
            //    if (responce.IsSuccessStatusCode)
            //    {
            //        MessageBox.Show($"{responce.Content.ReadAsStringAsync()}");
            //    }
            //    else
            //    {
            //        MessageBox.Show($"{responce.StatusCode}");
            //    }
            //}

            AddUser addUser = new AddUser();
            addUser.Show();
        }

        private  void Open_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

            OpenUser openUser = new OpenUser(this);
            openUser.Show();
            addButton.IsEnabled = false;
            

        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditUser editUser = new EditUser();
            editUser.Show();
        }
    }
}
