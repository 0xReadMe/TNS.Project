using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TNS.Front_end.CRM;
using TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;

namespace TNS.Front_end.EQUIPMENT
{
    /// <summary>
    /// Логика взаимодействия для EquipmentAccessNetwork.xaml
    /// </summary>
    public partial class EquipmentAccessNetwork : Page
    {
        List<GetAllBaseStations_GET> _equipment;
        string chooseFilter;


        public EquipmentAccessNetwork()
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
            AddEquipmentAccessNetwork addWindow = new(this);
            addWindow.Show();
        }

        private void testEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = "";
            _equipment = ApiContext.Get<GetAllBaseStations_GET>($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/testAllBaseStations");
            Update(_equipment);
            FilterBlock.ButtonThicknessChange(addButton, btnStack);
            ComboBoxSort.FillComboBox(ComboBoxSort.Filters, CBSort);
            CBSort.SelectedIndex = 0;
        }

        private void Open_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllBaseStations_GET;
            OpenEquipmentAccessNetwork openWindow = new(this, subscriber);
            openWindow.Show();
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllBaseStations_GET;
            EditEquipmentAccessNetwork editWindow = new(this, subscriber);
            editWindow.Show();
        }

        private void RefreshButton_Click(object sender, MouseButtonEventArgs e)
        {
            chooseFilter = "";
            _equipment = ApiContext.Get<GetAllBaseStations_GET>($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/equipment/getAllBaseStations");
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

                    case "Площадь зоны покрытия":
                        SBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    case "Тип антенны":
                        TypeAntennaBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        break;

                    case "Стандарт связи":
                        CommunicationProtocolBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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
            List<GetAllBaseStations_GET> findList = FindInfo.Find<GetAllBaseStations_GET>(membersDataGrid, txtSearch);
            Update(findList);
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var result = ComboBoxSort.ChangeCB<GetAllBaseStations_GET>(CBSort, chooseFilter, membersDataGrid);
            Update(result);
        }

        private void FrequencyBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(FrequencyBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_equipment);
        }

        private void SBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(SBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);
            CBSort.SelectedIndex = 0;

            Update(_equipment);
        }

        private void TypeAntennaBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(TypeAntennaBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);

            CBSort.SelectedIndex = 0;

            Update(_equipment);
        }

        private void CommunicationProtocolBtn_Click(object sender, RoutedEventArgs e)
        {
            chooseFilter = FilterBlock.ButtonThicknessChange(CommunicationProtocolBtn, btnStack);
            ComboBoxSort.FillComboBox(chooseFilter, CBSort);

            CBSort.SelectedIndex = 0;

            Update(_equipment);
        }

        private void Delete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ellipse = sender as Ellipse;
            var subscriber = ellipse.DataContext as GetAllBaseStations_GET;
            string messageBox = $"Вы точно хотите удалить оборудование \"{subscriber.BaseStationName}\"?";

            var dialog = new MessageWindow(messageBox, subscriber);
        }

        private void Update(List<GetAllBaseStations_GET> sub) => membersDataGrid.ItemsSource = sub;
    }
}
