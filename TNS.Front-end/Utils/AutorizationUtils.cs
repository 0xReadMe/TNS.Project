using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

    static class AutorizationUtils
    {
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
        public static void UpdateList<T>(DataGrid dg, List<T> ml) where T : class
            => dg.ItemsSource = ml;
 
    }
}
