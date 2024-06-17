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

namespace TNS.Front_end.Help
{
    /// <summary>
    /// Логика взаимодействия для HelpUsers.xaml
    /// </summary>
    public partial class HelpUsers : Window
    {
        public HelpUsers()
        {
            InitializeComponent();

            List<string> helps = [
                "Вопросы по интеграции с корпоративными системами",
                "Запросы по расширению функциональности приложения",
                "Проблемы с доступом и авторизацией",
                "Предложения по улучшению и оптимизации приложения",
                "Вопросы по администрированию приложения"
                ];

            cbHelp.ItemsSource = helps;
            cbHelp.SelectedIndex = 0;
        }
        private void Image_MouseDown_Minimized(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;                   //  свернуть окно
        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e) => Close();                                                   //  закрыть окно

        private void SendMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
