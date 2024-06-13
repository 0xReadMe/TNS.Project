using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace TNS.Front_end;

/// <summary>
/// Логика взаимодействия для Autorization.xaml
/// </summary>
public partial class Autorization : Window
{
    public Autorization()
    {
        InitializeComponent();

        //code.Visibility = Visibility.Hidden;
        //textCode.Visibility = Visibility.Hidden;
        //refreshButton.Visibility = Visibility.Hidden;

    }
    private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)       => Close();                             //  закрыть окно
    private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)   => WindowState = WindowState.Minimized; //  свернуть окно
    private void Image_MouseDown_Del(object sender, MouseButtonEventArgs e)         => code.Clear();                        //  обновление одноразового кода?
    
    /// <summary>
    /// Логика авторизации и аутентификации
    /// </summary>
    private void Authorization_Click(object sender, RoutedEventArgs e)
    {
        //if (Autorization) 
        //{
        //    MainWindow main = new MainWindow();
        //    main.Show();
        //    Close();
        //}
    }
}