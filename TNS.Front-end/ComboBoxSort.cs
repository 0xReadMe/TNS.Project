using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using TNS.Front_end.CRM.MODELS;
using TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end;

class ComboBoxSort
{
    public static List<string> Filters { get; } = ["Выберите сортировку", "По возрастанию", "По убыванию"];
    public static List<string> Services { get; } = ["Интернет", "Мобильная связь", "Телевидение", "Видеонаблюдение"];
    public static List<string> Antenna { get; } = ["Всенаправленная", "Направленная", "Параболическая", "Яги", "Патч", "Дипольная", "Бинаправленная", "Логопериодическая"];
    public static List<string> Protocols { get; } = ["TCP/IP", "UDP", "ICMP", "SNMP", "HTTP", "HTTPS", "FTP", "SFTP", "TELNET", "SSH", "SIP", "RTP", "RTSP"];
    public static List<string> DTT { get; } = ["Ethernet", "Wi-Fi", "Bluetooth", "USB", "Optical Fiber", "SHDSL", "ADSL", "VDSL", "G.Fast", "LTE", "5G"];
    public static List<string> Status { get; } = ["Новая", "В работе", "Закрыта"];
    public static List<string> TypeEquipment { get; } = ["Маршрутизатор", "Коммутатор", "Точка доступа", "Сервер", "Шлюз", "Модем", "Концентратор", "Принтер", "Телефон", "Ноутбук", "Планшет"];
    
    public static void FillComboBox(List<string> input, ComboBox cb)
    {
        cb.Items.Clear();
        foreach (string text in input)
        {
            TextBlock tb = new()
            {
                Text = text
            };
            cb.Items.Add(tb);
        }
    }
    public static void FillComboBox(string header, ComboBox cb)
    {
        List<string> filtersButton = [];
        foreach (var filter in Filters)
            filtersButton.Add($"{header}: " + filter.ToLower());
        FillComboBox(filtersButton, cb);
    }

    public static List<T> ChangeCB<T>(ComboBox comboBox, string chooseFilter, DataGrid entity)
    {
        var tb = (TextBlock)comboBox.SelectedValue;

        ICollectionView view = CollectionViewSource.GetDefaultView(entity.ItemsSource);
        List<T> currentItems = new(view.Cast<T>());

        if (tb != null)
        {
            foreach (var filter in Filters)
            {
                if (tb.Text.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (typeof(T) == typeof(GetSubscriber_GET))
                    {
                        List<T>? sortedSubscribers = chooseFilter switch
                        {
                            "Активные" => Filter(filter, x => x.FirstName, currentItems as List<GetSubscriber_GET>) as List<T>,
                            "Неактивные" => Filter(filter, x => x.FirstName, currentItems as List<GetSubscriber_GET>) as List<T>,
                            "Услуги" => Filter(filter, x => x.Services, currentItems as List<GetSubscriber_GET>) as List<T>,
                            "Лицевой счет" => Filter(filter, x => x.PersonalBill.ToString(), currentItems as List<GetSubscriber_GET>) as List<T>,
                            "Номер договора" => Filter(filter, x => x.ContractNumber, currentItems as List<GetSubscriber_GET>) as List<T>,
                            "ФИО" => Filter(filter, x => x.FirstName, currentItems as List<GetSubscriber_GET>) as List<T>,
                            _ => Filter(filter, x => x.FirstName, currentItems as List<GetSubscriber_GET>) as List<T>,
                        };
                        return sortedSubscribers;
                    }

                    if (typeof(T) == typeof(GetAllBaseStations_GET))
                    {
                        List<T>? sorteDequipment = chooseFilter switch
                        {
                            "Частота" => Filter(filter, x => x.Frequency, currentItems as List<GetAllBaseStations_GET>) as List<T>,
                            "Площадь зоны покрытия" => Filter(filter, x => x.S, currentItems as List<GetAllBaseStations_GET>) as List<T>,
                            "Тип антенны" => Filter(filter, x => x.TypeAntenna, currentItems as List<GetAllBaseStations_GET>) as List<T>,
                            "Стандарт связи" => Filter(filter, x => x.CommunicationProtocol, currentItems as List<GetAllBaseStations_GET>) as List<T>,
                            _ => Filter(filter, x => x.BaseStationName, currentItems as List<GetAllBaseStations_GET>) as List<T>,
                        };
                        return sorteDequipment;
                    }

                    if (typeof(T) == typeof(GetAllEquipments_GET))
                    {
                        List<T>? sorteDequipment = chooseFilter switch
                        {
                            "Частота" => Filter(filter, x => x.Frequency, currentItems as List<GetAllEquipments_GET>) as List<T>,
                            "Коэффициент затухания" => Filter(filter, x => x.AttenuationCoefficient, currentItems as List<GetAllEquipments_GET>) as List<T>,
                            "Технология передачи данных" => Filter(filter, x => x.DTT, currentItems as List<GetAllEquipments_GET>) as List<T>,
                            "Расположение" => Filter(filter, x => x.Address, currentItems as List<GetAllEquipments_GET>) as List<T>,
                            _ => Filter(filter, x => x.Name, currentItems as List<GetAllEquipments_GET>) as List<T>,
                        };
                        return sorteDequipment;
                    }

                    if (typeof(T) == typeof(GetAllEquipments_GET))
                    {
                        List<T>? sorteDequipment = chooseFilter switch
                        {
                            "Статус" => Filter(filter, x => x.Status, currentItems as List<CRM_viewmodel>) as List<T>,
                            "Тип оборудования" => Filter(filter, x => x.TypeOfEquipment, currentItems as List<CRM_viewmodel>) as List<T>,
                            "Услуги" => Filter(filter, x => x.Service, currentItems as List<CRM_viewmodel>) as List<T>,
                            _ => Filter(filter, x => x.SubscriberNumber, currentItems as List<CRM_viewmodel>) as List<T>,
                        };
                        return sorteDequipment;
                    }
                }
            }
        }
        return currentItems;
    }

    static List<T> Filter<T>(string filter, Func<T, string> predicate, List<T> sort)
    {
        List<T> filtersMembersChanged = filter.ToLower() switch
        {
            "по возрастанию" => [.. sort.OrderBy(predicate)],
            "по убыванию" => [.. sort.OrderByDescending(predicate)],
            _ => new(sort),
        };
        return filtersMembersChanged;

        //if (servicesPressed)
        //{
        //    localMembers = membersCopy.Where(
        //        m => m.Services == tb.Text)
        //        .ToList();
        //    membersChanged = localMembers;
        //    SubscribersUtils.UpdateList(membersDataGrid, localMembers);
        //    servicesPressed = false;
        //}
    }

    static List<T> Filter<T>(string filter, Func<T, int> predicate, List<T> sort)
    {
        List<T> filtersMembersChanged = filter.ToLower() switch
        {
            "по возрастанию" => [.. sort.OrderBy(predicate)],
            "по убыванию" => [.. sort.OrderByDescending(predicate)],
            _ => new(sort),
        };
        return filtersMembersChanged;
    }

    static List<T> Filter<T>(string filter, Func<T, double> predicate, List<T> sort)
    {
        List<T> filtersMembersChanged = filter.ToLower() switch
        {
            "по возрастанию" => [.. sort.OrderBy(predicate)],
            "по убыванию" => [.. sort.OrderByDescending(predicate)],
            _ => new(sort),
        };
        return filtersMembersChanged;
    }
}
