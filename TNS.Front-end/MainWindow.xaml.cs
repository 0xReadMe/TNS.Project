using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace TNS.Front_end;

/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    const double panelWidth = 330;                                          // ======= выезжающее меню слева
    bool hidden = true;                                                     // =======
                                                                            // =======
    DispatcherTimer timer = new()                                           // =======
    {                                                                       // =======
        Interval = new TimeSpan(0, 0, 0, 0, 10)                             // =======
    };                                                                      // ======= выезжающее меню слева

    List<Page> pages = [ new Subscribers(), new Equipment(), new CRM() ];   // список страниц фрейма

    /// <summary>
    /// Страница после авторизации - абоненты.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        ContentFrame.Content = pages[0];
        timer.Tick += Timer_Tick;
    }

    /// <summary>
    /// Анимация выезжающего меню слева
    /// </summary>
    private void Timer_Tick(object sender, EventArgs e)
    {
        if (hidden)
        {
            sidePanel.Width += 15;
            if (sidePanel.Width >= panelWidth)
            {
                timer.Stop();
                hidden = false;
            }
        }
        else
        {
            sidePanel.Width -= 15;
            if (sidePanel.Width <= 100)
            {
                timer.Stop();
                hidden = true;
            }
        }
    }
    private void ListView_MouseEnter(object sender, MouseEventArgs e) => timer.Start();                                                     //  начало анимации меню

    private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
    private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно

    private void ListViewItem_MouseDown_MainWindow(object sender, MouseButtonEventArgs e) => ContentFrame.Navigate(typeof(MainWindow));     //  навигация
    private void Abonentter_MouseDown(object sender, MouseButtonEventArgs e) => ContentFrame.Content = pages[0];                            //  переход на страницу абонентов
    private void Equipment_MouseDown(object sender, MouseButtonEventArgs e) => ContentFrame.Content = pages[1];                             //  переход на страницу оборудования
    private void CRM_MouseDown(object sender, MouseButtonEventArgs e) => ContentFrame.Content = pages[2];                                   //  переход на страницу CRM
}