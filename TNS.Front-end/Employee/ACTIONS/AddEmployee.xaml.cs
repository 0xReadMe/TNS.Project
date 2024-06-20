using System.Windows;
using System.Windows.Input;
using TNS.Front_end.Employee.MODELS;

namespace TNS.Front_end.Employee;

public partial class AddEmployee : Window
{
    public AddEmployee()
    {
        InitializeComponent();

        cbPosition.ItemsSource = ComboBoxSort.Roles;
        cbPosition.SelectedIndex = 0;
    }
    private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
    private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        tbFullName.Clear();
        cbPosition.ItemsSource = ComboBoxSort.Roles;
        cbPosition.SelectedIndex = 0;
        tbPhone.Clear();
        tbEmail.Clear();
        tbDOB.SelectedDate = DateTime.Now;
        tbTelegramm.Clear();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            ApiContext.Get($"https://localhost:{Configurator.GetPort().Normalize().TrimStart().TrimEnd()}/employee/add/" +
                $"&{tbPhone.Text}" +
                $"&{cbPosition.SelectedIndex+1}" +
                $"&{tbEmail.Text}" +
                $"&{tbFullName.Text}" +
                $"&default.jpg" +
                $"&{tbTelegramm.Text}" +
                $"&DateOfIssueOfPassport={tbDOB.SelectedDate.Value.Year}-{tbDOB.SelectedDate.Value.Month}-{tbDOB.SelectedDate.Value.Day}" +
                $"&{tbPassword.Text}");

        }
        catch (Exception ex)
        {
            //_mainFrame.addButton.IsEnabled = true;
            var dialog = new MessageWindow($"{ex}");
        }
        //_mainFrame.addButton.IsEnabled = true;
        Close();
    }
}
