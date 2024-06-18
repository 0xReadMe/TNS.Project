using System.Windows;
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
        string chooseFilter;


        List<Page> pages = [new EquipmentMagisralNetworks(), new EquipmentAccessNetwork()];   // список страниц фрейма

        public Equipment()
        {
            InitializeComponent();
            ContentFrameEquipment.Content = pages[0];
            emnBtn.BorderThickness = new Thickness(0, 0, 0, 2);
        }

        private void EMN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ContentFrameEquipment.Content = pages[0];  
            chooseFilter = FilterBlock.ButtonThicknessChange(emnBtn, btnStackFrame);

        }

        private void EAN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ContentFrameEquipment.Content = pages[1];                             //  переход на страницу оборудования сетей доступа
            chooseFilter = FilterBlock.ButtonThicknessChange(eanBtn, btnStackFrame);

        }
    }
}
