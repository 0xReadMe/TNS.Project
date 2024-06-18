using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TNS.Front_end.CRM;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;


namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для EquipmentMagisralNetworks.xaml
    /// </summary>
    public partial class EquipmentMagisralNetworks : Page
    {
        List<GetAllEquipments_GET> _equipment;
        string chooseFilter;


        public EquipmentMagisralNetworks()
        {
            InitializeComponent();


            membersDataGrid.ItemsSource = _equipment;

            MouseButtonEventArgs args = new(Mouse.PrimaryDevice, 0, MouseButton.Left)
            {
                RoutedEvent = Image.MouseDownEvent
            };
            refreshBtn.RaiseEvent(args);
        }


        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddEquipmentMagisralNetworks addWindow = new AddEquipmentMagisralNetworks();
            addWindow.Show();
        }

        private void testEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            TestEquipment testWindow = new TestEquipment();
            testWindow.Show();
        }

        private void Open_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllEquipments_GET;
            OpenEquipmentMagisralNetworks openWindow  = new OpenEquipmentMagisralNetworks(this, subscriber);
            openWindow.Show();
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllEquipments_GET;
            EditEquipmentMagisralNetworks editWindow = new EditEquipmentMagisralNetworks(this, subscriber);
            editWindow.Show();
        }

        private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {
            chooseFilter = "";
            _equipment = ApiContext.Get<GetAllEquipments_GET>($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/getAllEquipment");
            Update(_equipment);
            FilterBlock.ButtonThicknessChange(addButton, btnStack);
            ComboBoxSort.FillComboBox(ComboBoxSort.Filters, CBSort);
            CBSort.SelectedIndex = 0;
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                switch (chooseFilter)
                {
                    case "Частота":
                        FrequencyBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    case "Коэффициент затухания":
                        AttenuationCoefficientBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    case "Технология передачи данных":
                        DTTBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    case "Расположение":
                        AddressBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    default:
                        MouseButtonEventArgs args = new(Mouse.PrimaryDevice, 0, MouseButton.Left)
                        {
                            RoutedEvent = Image.MouseDownEvent
                        };
                        refreshBtn.RaiseEvent(args);
                        break;
                }
            }
            List<GetAllEquipments_GET> findList = FindInfo.Find<GetAllEquipments_GET>(membersDataGrid, txtSearch);
            Update(findList);
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var result = ComboBoxSort.ChangeCB<GetAllEquipments_GET>(CBSort, chooseFilter, membersDataGrid);
            Update(result);
        }

        private void FrequencyBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(FrequencyBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_equipment);
        }

        private void AttenuationCoefficientBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(AttenuationCoefficientBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_equipment);
        }

        private void DTTBtn_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxSort.FillComboBox(ComboBoxSort.DTT, CBSort);
            chooseFilter = FilterBlock.ButtonThicknessChange(DTTBtn, btnStack);
            CBSort.SelectedIndex = 0;

            Update(_equipment);
        }

        private void AddressBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(AddressBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_equipment);
        }

        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllEquipments_GET;
            string messageBox = $"Вы точно хотите удалить оборудование \"{subscriber.Name}\"?";
        }

        private void Update(List<GetAllEquipments_GET> sub) => membersDataGrid.ItemsSource = sub;
    }
}
