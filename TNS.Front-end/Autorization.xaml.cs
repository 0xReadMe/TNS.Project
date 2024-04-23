using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TNS.Front_end
{


    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        const double panelWidth = 255;
        bool hidden = true;

        DispatcherTimer timer = new()
        {
            Interval = new TimeSpan(0, 0, 0, 0, 10)
        };

        List<Page> pages = [
            new MainFrame()
        ];

        public Autorization()
        {
            InitializeComponent();
            ContentFrame.Content = pages[0];
            timer.Tick += Timer_Tick;
        }

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

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)
            => WindowState = WindowState.Minimized;
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
            => Close();
        private void ListViewItem_MouseDown_Autorization(object sender, MouseButtonEventArgs e)
            => ContentFrame.Navigate(typeof(Autorization));
        private void ListView_MouseEnter(object sender, MouseEventArgs e)
            => timer.Start();
    }
}
