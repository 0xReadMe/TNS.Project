using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using TNS.Front_end.CRM.MODELS;
using TNS.Front_end.EQUIPMENT.BASESTATIONS.MODELS;
using TNS.Front_end.EQUIPMENT.MODELS.EQUIPMENT;
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

        if (typeof(T) == typeof(GetAllBaseStations_GET))
        {
            List<GetAllBaseStations_GET> result = (List<GetAllBaseStations_GET>)Convert.ChangeType(currentItems, typeof(List<GetAllBaseStations_GET>));
            result = result.Where(sub =>
                                sub.BaseStationName.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.TypeAntenna.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.CommunicationProtocol.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.Frequency.ToString().Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.S.ToString().Contains(search.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return result as List<T>;
        }

        if (typeof(T) == typeof(GetAllEquipments_GET))
        {
            List<GetAllEquipments_GET> result = (List<GetAllEquipments_GET>)Convert.ChangeType(currentItems, typeof(List<GetAllEquipments_GET>));
            result = result.Where(sub =>
                                sub.Name.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.Frequency.ToString().Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.DTT.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.AttenuationCoefficient.ToString().Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.Address.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return result as List<T>;
        }

        if (typeof(T) == typeof(CRM_viewmodel))
        {
            List<CRM_viewmodel> result = (List<CRM_viewmodel>)Convert.ChangeType(currentItems, typeof(List<CRM_viewmodel>));
            result = result.Where(sub =>
                                sub.SubscriberNumber.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.ProblemDescription.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.TypeOfEquipment.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase) ||
                                sub.Status.Contains(search.Text, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return result as List<T>;
        }
        return currentItems;
    }
}
