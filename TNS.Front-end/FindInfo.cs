using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using TNS.Front_end.SUBSCRIBERS.MODELS;

namespace TNS.Front_end;

class FindInfo
{
    public static List<T> Find<T>(DataGrid entity, TextBox search) 
    {
        ICollectionView view = CollectionViewSource.GetDefaultView(entity.ItemsSource);
        List<T> currentItems = new(view.Cast<T>());

        if (typeof(T) == typeof(GetSubscriber_GET)) 
        {
            List<GetSubscriber_GET> result = (List<GetSubscriber_GET>)Convert.ChangeType(currentItems, typeof(List<GetSubscriber_GET>));
            result = result.Where(sub =>
                                sub.FirstName.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.MiddleName.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.LastName.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.PersonalBill.ToString().Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.PhoneNumber.ToString().Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.Services.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();
            
            return result as List<T>;
        }
        return currentItems;
    }
}
