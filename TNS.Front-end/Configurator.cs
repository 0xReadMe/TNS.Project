using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace TNS.Front_end
{
    class Configurator
    {
        public static string GetPort() 
        {
            using StreamReader reader = new("port.txt");
            string text = reader.ReadToEnd();
            return text;
        }
    }
}
