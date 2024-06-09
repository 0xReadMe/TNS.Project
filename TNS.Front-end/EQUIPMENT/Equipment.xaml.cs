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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TNS.Front_end.CRM;
using TNS.Front_end.EQUIPMENT;

namespace TNS.Front_end
{
    /// <summary>
    /// Логика взаимодействия для Equipment.xaml
    /// </summary>
    public partial class Equipment : Page
    {
        
        List<Page> pages = [new EquipmentMagisralNetworks(), new EquipmentAccessNetwork()];   // список страниц фрейма

        public Equipment()
        {
            InitializeComponent();
            ContentFrameEquipment.Content = pages[0];

        }

        private void EMN_MouseDown(object sender, MouseButtonEventArgs e) => ContentFrameEquipment.Content = pages[0];                            //  переход на страницу оборудования магистральных сетей
        private void EAN_MouseDown(object sender, MouseButtonEventArgs e) => ContentFrameEquipment.Content = pages[1];                             //  переход на страницу оборудования сетей доступа

    }
}
