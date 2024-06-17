using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end;

class ComboBoxSort
{
    public static List<string> Filters  { get; } = ["По умолчанию", "По возрастанию", "По убыванию"];
    public static List<string> Services { get; } = ["Интернет", "Мобильная связь", "Телевидение", "Видеонаблюдение"];

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
                            "Активные"          => Filter(filter, x => x.FirstName, currentItems as List<GetSubscriber_GET>) as List<T>,
                            "Неактивные"        => Filter(filter, x => x.FirstName, currentItems as List<GetSubscriber_GET>) as List<T>,
                            "Услуги"            => Filter(filter, x => x.Services, currentItems as List<GetSubscriber_GET>) as List<T>,
                            "Лицевой счет"      => Filter(filter, x => x.PersonalBill.ToString(), currentItems as List<GetSubscriber_GET>) as List<T>,
                            "Номер договора"    => Filter(filter, x => x.ContractNumber, currentItems as List<GetSubscriber_GET>) as List<T>,
                            "ФИО"               => Filter(filter, x => x.FirstName, currentItems as List<GetSubscriber_GET>) as List<T>,
                            _                   => Filter(filter, x => x.FirstName, currentItems as List<GetSubscriber_GET>) as List<T>,
                        };
                        return sortedSubscribers;
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
}
