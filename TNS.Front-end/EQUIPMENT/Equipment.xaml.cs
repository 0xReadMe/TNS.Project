using System.Windows.Controls;
using System.Windows.Input;
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
