using System.Windows;
using System.Windows.Input;

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
            Hide();
            Autorization autorization = new Autorization();
            autorization.Show();
            //AddUser addUser = new AddUser();
            //addUser.Show();
            Close();
        }

        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)
        {
           WindowState = WindowState.Minimized;
        }

        private void Image_MouseDown_Del(object sender, MouseButtonEventArgs e)
        {
            code.Clear();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}