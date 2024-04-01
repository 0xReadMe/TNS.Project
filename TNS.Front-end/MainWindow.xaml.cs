using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TNS.Front_end
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            code.Visibility = Visibility.Hidden;
            textCode.Visibility = Visibility.Hidden;
            refreshButton.Visibility = Visibility.Hidden;

            this.Hide();
            Autorization autorization = new();
            autorization.Show();
            this.Close();
        }

        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseDown_Del(object sender, MouseButtonEventArgs e)
        {
            this.code.Clear();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}