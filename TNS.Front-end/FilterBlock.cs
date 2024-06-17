using System.Windows.Controls;
using System.Windows;

namespace TNS.Front_end;

class FilterBlock
{
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
}
