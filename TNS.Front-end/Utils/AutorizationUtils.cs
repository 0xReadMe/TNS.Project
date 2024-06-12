using System.Windows;
using System.Windows.Controls;

namespace TNS.Front_end.Utils
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

    static class MainFrameUtils
    {
        public static List<string> filters { get; set; } = 
            [
                "По умолчанию",
                "По возрастанию",
                "По убыванию"
            ];

        public static List<string> GetUniqServices(List<Member> members)
        {
            List<string> services = [];
            foreach (var member in members)
                services.Add(member.Services);
            return services.Distinct().ToList();
        }

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
            for(int i = 0; i < buttons.Count; i++)
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
}
