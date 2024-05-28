using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TNS.Front_end
{
    /// <summary>
    /// Логика взаимодействия для OpenUser.xaml
    /// </summary>
    public partial class OpenUser : Window
    {
        MainFrame _mainFrame;
        public OpenUser(MainFrame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e)
            => WindowState = WindowState.Minimized;
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            _mainFrame.addButton.IsEnabled = true;
            Close();
        }
    }
}
