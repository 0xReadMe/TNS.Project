using System.Windows;
using System.Windows.Controls;

namespace TNS.Front_end.SUBSCRIBERS;

static class SubscribersUtils
{
    public static List<string> filters { get; set; } =
        [
            "По умолчанию",
            "По возрастанию",
            "По убыванию"
        ];


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
        foreach (var filter in filters)
            filtersButton.Add($"{header} " + filter.ToLower());
        FillComboBox(filtersButton, cb);
    }

    public static string ButtonThicknessChange(Button btn, StackPanel sp)
    {
        btn.BorderThickness = new Thickness(0, 0, 0, 2);
        string result = btn.Content.ToString();
        var buttons = sp.Children.OfType<Button>().ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i] != btn)
            {
                buttons[i].BorderThickness = new Thickness(0);
            }
        }
        return result;
    }

    public static void UpdateList<T>(DataGrid dg, List<T> ml) where T : class
        => dg.ItemsSource = ml;

}
